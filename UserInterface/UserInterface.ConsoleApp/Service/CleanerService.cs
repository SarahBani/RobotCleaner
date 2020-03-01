using System;
using System.Collections.Generic;
using System.Linq;

namespace UserInterface.ConsoleApp.Service
{
    public class CleanerService
    {

        #region Prperties

        //private Point _currentPoint;
        private (int X, int Y) _currentPoint;

        //private HashSet<Point> _cleanedPoints;
        private HashSet<(int X, int Y)> _cleanedPoints;

        #endregion /Prperties

        #region Constructors

        public CleanerService()
        {

        }

        #endregion /Constructors

        #region Methods

        public int GetUniqueCleanedPoints(string startingCoordinates, string[] movementCommands)
        {
            this._cleanedPoints = new HashSet<(int, int)>(GetTotalPointsCount(movementCommands));
            SetStartingPoint(startingCoordinates);
            foreach (var command in movementCommands)
            {
                Move(char.Parse(command.Substring(0, 1)), int.Parse(command.Substring(2)));
            }
            return this._cleanedPoints.Count();
        }

        /// <summary>
        /// all cleaning points without distinct
        /// </summary>
        /// <param name="movementCommands"></param>
        /// <returns></returns>
        private int GetTotalPointsCount(string[] movementCommands)
        {
            return movementCommands.Select(q => int.Parse(q.Substring(2))).Sum() + 1;
        }

        private void SetStartingPoint(string startingCoordinates)
        {
            var startingPoint = startingCoordinates.Split(" ");
            this._currentPoint = (int.Parse(startingPoint[0]), int.Parse(startingPoint[1]));
            AddCleanedPoint(this._currentPoint);
        }

        private void AddCleanedPoint((int X, int Y) point)
        {
            this._cleanedPoints.Add((point.X, point.Y));
        }

        private void Move(char direction, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                this._currentPoint = GetNewPoint(direction);
                AddCleanedPoint(this._currentPoint);
            }
        }

        private (int X, int Y) GetNewPoint(char direction)
        {
            (int X, int Y) newPoint = default;
            switch (direction)
            {
                case 'E':
                    newPoint = (this._currentPoint.X + 1, this._currentPoint.Y);
                    break;
                case 'W':
                    newPoint = (this._currentPoint.X - 1, this._currentPoint.Y);
                    break;
                case 'S':
                    newPoint = (this._currentPoint.X, this._currentPoint.Y - 1);
                    break;
                case 'N':
                    newPoint = (this._currentPoint.X, this._currentPoint.Y + 1);
                    break;
            }
            return newPoint;
        }

        //private Point GetNewPoint(char direction)
        //{
        //    Point newPoint = default;
        //    switch (direction)
        //    {
        //        case 'E':
        //            newPoint = new Point(this._currentPoint.X + 1, this._currentPoint.Y);
        //            break;
        //        case 'W':
        //            newPoint = new Point(this._currentPoint.X - 1, this._currentPoint.Y);
        //            break;
        //        case 'S':
        //            newPoint = new Point(this._currentPoint.X, this._currentPoint.Y - 1);
        //            break;
        //        case 'N':
        //            newPoint = new Point(this._currentPoint.X, this._currentPoint.Y + 1);
        //            break;
        //    }
        //    return newPoint;
        //}

        #endregion /Methods

    }
}
