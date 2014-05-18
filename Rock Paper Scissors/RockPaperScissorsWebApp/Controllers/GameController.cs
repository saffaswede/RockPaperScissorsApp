using System.Linq;
using System.Web.Mvc;
using RockPaperScissorsWebApp.Enums;
using RockPaperScissorsWebApp.Factories;
using RockPaperScissorsWebApp.Models;
using RockPaperScissorsWebApp.Repositories;
using RockPaperScissorsWebApp.Services;

namespace RockPaperScissorsWebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IPlayerService _playerService;
        private ScorecardViewModel _scorecardViewModel;

        public GameController()
        {
            var roundRepository = new SessionRepository<Round>("Rounds");
            _gameService = new GameService(roundRepository);

            var strategyFactory = new StrategyFactory();
            var playerRepository = new SessionRepository<Player>("Players");
            _playerService = new PlayerService(strategyFactory, playerRepository);
        }

        public GameController(IGameService gameService,
                              IPlayerService playerService)
        {
            _gameService = gameService;
            _playerService = playerService;
        }

        public ActionResult Index()
        {
            _gameService.Reset();
            _playerService.Reset();

            return View();
        }

        public ActionResult NewGame(GameType gameType)
        {
            if (gameType == GameType.HumanVsComputer)
            {
                _playerService.CreateOneComputerAndOneHumanPlayer("Player 1", "Player 2");
                return RedirectToAction("ChooseHumanGesture");
            }
            _playerService.CreateTwoComputerPlayers("Player 1", "Player 2");
            return RedirectToAction("GetComputerGestures");
        }

        public ActionResult OldGame()
        {
            var players = _playerService.GetPlayers().ToList();
            return RedirectToAction(players.Any(p => p.PlayerType == PlayerType.Human) ? "ChooseHumanGesture" : "GetComputerGestures");
        }

        public ActionResult ChooseHumanGesture()
        {
            var viewModel = _gameService.GetScorecard().ToList();
            return View(viewModel);
        }

        public ActionResult GetComputerGestures()
        {
            var playerOnesGestures = _gameService.GetScorecard().Select(g => g.Player1Gesture).ToList();
            var playerTwosGestures = _gameService.GetScorecard().Select(g => g.Player2Gesture).ToList();
            var players = _playerService.GetPlayers().ToList();
            players.First().Gesture = _playerService.GetComputerGesture(playerTwosGestures);
            players.Last().Gesture = _playerService.GetComputerGesture(playerOnesGestures);
            _playerService.SavePlayers(players); 
            return RedirectToAction("Scorecard");
        }

        public ActionResult GetHumanGesture(Gesture gesture)
        {
            var players = _playerService.GetPlayers().ToList();
            players.First().Gesture = gesture;
            var playerOnesGestures = _gameService.GetScorecard().Select(g => g.Player1Gesture).ToList();
            players.Last().Gesture = _playerService.GetComputerGesture(playerOnesGestures);
            _playerService.SavePlayers(players);
            return RedirectToAction("Scorecard");
        }
        
        public ActionResult Scorecard()
        {
            var players = _playerService.GetPlayers().ToList();
            var winner = _gameService.CalculateWinner(players.First(), players.Last());
            var message = winner != null ? string.Format("The winner is {0}.", winner.Name) : "It is a draw.";
            _gameService.RecordResult(players.First(), players.Last(), winner);
            _scorecardViewModel = new ScorecardViewModel
            {
                Message = message,
                Player1Name = players.First().Name,
                Player1Score = players.First().CurrentScore,
                Player1Gesture = players.First().Gesture,
                Player2Name = players.Last().Name,
                Player2Score = players.Last().CurrentScore,
                Player2Gesture = players.Last().Gesture,
                History = _gameService.GetScorecard().ToList()
            };
            return View(_scorecardViewModel);
        }
    }
}