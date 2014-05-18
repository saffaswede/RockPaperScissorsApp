using System.Collections.Generic;
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
        private static IList<Player> _players;
        private static IGameService _gameService;
        private static IPlayerService _playerService;
        private static ScorecardViewModel _scorecardViewModel;
        private static RoundRepository _roundRepository;

        public GameController()
        {
            _roundRepository = new RoundRepository();
            _gameService = new GameService(_roundRepository);
            IStrategyFactory strategyFactory = new StrategyFactory();
            _playerService = new PlayerService(strategyFactory);
        }

        public ActionResult Index()
        {
            _players = new List<Player>();
            _gameService.Reset();

            return View();
        }

        public ActionResult NewGame(GameType gameType)
        {
            if (gameType == GameType.HumanVsComputer)
            {
                _players = _playerService.CreateOneComputerAndOneHumanPlayer("Player 1", "Player 2").ToList();
                return RedirectToAction("ChooseHumanGesture");
            }
            _players = _playerService.CreateTwoComputerPlayers("Player 1", "Player 2").ToList();
            return RedirectToAction("GetComputerGestures");
        }

        public ActionResult OldGame()
        {
            return RedirectToAction(_players.Any(p => p.PlayerType == PlayerType.Human) ? "ChooseHumanGesture" : "GetComputerGestures");
        }

        public ActionResult ChooseHumanGesture()
        {
            return View();
        }

        public ActionResult GetComputerGestures()
        {
            var playerOnesGestures = _gameService.GetScorecard().Select(g => g.Player1Gesture).ToList();
            var playerTwosGestures = _gameService.GetScorecard().Select(g => g.Player2Gesture).ToList();
            _players.First().Gesture = _playerService.GetComputerGesture(playerTwosGestures);
            _players.Last().Gesture = _playerService.GetComputerGesture(playerOnesGestures);
            return RedirectToAction("Scorecard");
        }

        public ActionResult GetHumanGesture(Gesture gesture)
        {
            var playerOnesGestures = _gameService.GetScorecard().Select(g => g.Player1Gesture).ToList();
            _players.First().Gesture = gesture;
            _players.Last().Gesture = _playerService.GetComputerGesture(playerOnesGestures);
            return RedirectToAction("Scorecard");
        }
        
        public ActionResult Scorecard()
        {
            var winner = _gameService.CalculateWinner(_players.First(), _players.Last());
            _gameService.RecordResult(_players.First(), _players.Last(), winner);

            _scorecardViewModel = new ScorecardViewModel
            {
                Player1Name = _players.First().Name,
                Player1Score = _players.First().CurrentScore,
                Player1Gesture = _players.First().Gesture,
                Player2Name = _players.Last().Name,
                Player2Score = _players.Last().CurrentScore,
                Player2Gesture = _players.Last().Gesture,
                History = _gameService.GetScorecard().ToList()
            };

            TempData["ScorecardViewModel"] = _scorecardViewModel;

            return View(_scorecardViewModel);
        }
	}
}