using System;
using UserInterface.ConsoleApp.Service;
using Xunit;

namespace Test.UnitTest
{
    public class CleanerServiceTest : IDisposable
    {

        #region Properties

        private CleanerService _cleanerService { get; set; }

        private string _centerCoordinates = "0 0";

        private string _southWestCoordinates = "-100000 -100000";

        private string _southEastCoordinates = "100000 -100000";

        private string _northEastCoordinates = "100000 100000";

        private string _northWestCoordinates = "-100000 100000";

        private int _maxStep = 99999;

        private short _maxCommandsCount = 10000;

        #endregion /Properties

        #region Constructors

        public CleanerServiceTest()
        {
            this._cleanerService = new CleanerService();
        }

        #endregion /Constructors

        #region Methods

        public void Dispose()
        {
        }

        #region Simple Samples

        [Fact]
        public void GetUniqueCleanedPoints_2Commands_4UniqueCleans()
        {
            // Arrange
            short commandsCount = 2;
            string startingCoordinates = "10 22";
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = "E 2";
            movementCommands[1] = "N 1";
            int expectedResult = 4;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_3Commands_5Cleans_4UniqueCleans()
        {
            // Arrange
            short commandsCount = 3;
            string startingCoordinates = "10 22";
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = "E 2";
            movementCommands[1] = "N 1";
            movementCommands[2] = "S 1";
            int expectedResult = 4;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        #endregion /Simple Samples

        #region No Command

        [Fact]
        public void GetUniqueCleanedPoints_0Commands_1UniqueCleans()
        {
            // Arrange
            short commandsCount = 0;
            string startingCoordinates = "10 22";
            string[] movementCommands = new string[commandsCount];
            int expectedResult = 1;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        #endregion /No Command

        #region One Row Or Column Path From Center

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"E {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToWest_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"W {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToNorth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"N {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToSouth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"S {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        #endregion /One Row Or Column Path From Center

        #region One Row Or Column Path From Corners

        [Fact]
        public void GetUniqueCleanedPoints_FromSouthWestToEast_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._southWestCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"E {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromNorthWestToEast_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._northWestCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"E {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromSouthEastToWest_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._southEastCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"W {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromNorthEastToWest_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._northEastCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"W {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }


        [Fact]
        public void GetUniqueCleanedPoints_FromSouthWestToNorth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._southWestCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"N {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromSouthEastToNorth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._southEastCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"N {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromNorthWestToSouth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._northWestCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"S {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromNorthEastToSouth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1;
            string startingCoordinates = this._northEastCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"S {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        #endregion /One Row Or Column Path From Corners

        #region 1 Repetitive Path

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_1000UniqueCleans()
        {
            // Arrange
            short commandsCount = 2;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"E 999";
            movementCommands[1] = $"W 999";
            int expectedResult = 1000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 2;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"E {this._maxStep}";
            movementCommands[1] = $"W {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToWest_ReturnEast_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 2;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"W {this._maxStep}";
            movementCommands[1] = $"E {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToNorth_ReturnSouth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 2;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"N {this._maxStep}";
            movementCommands[1] = $"S {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToSouth_ReturnNorth_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 2;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            movementCommands[0] = $"S {this._maxStep}";
            movementCommands[1] = $"N {this._maxStep}";
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        #endregion /1 Repetitive Path

        #region 100 Repetitive Path

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_100Times_1000UniqueCleans()
        {
            // Arrange
            short commandsCount = 100;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} 999";
            }
            int expectedResult = 1000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_100Times_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 100;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} {this._maxStep}";
            }
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }
      
        #endregion /100 Repetitive Path
        
        #region 1000 Repetitive Path

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_1000Times_1000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1000;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} 999";
            }
            int expectedResult = 1000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_1000Times_10000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1000;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} 9999";
            }
            int expectedResult = 10000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }
        
        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_1000Times_100000UniqueCleans()
        {
            // Arrange
            short commandsCount = 1000;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} {this._maxStep}";
            }
            int expectedResult = 100000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        #endregion /1000 Repetitive Path

        #region Max Repetitive Path

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_10000Times_100UniqueCleans()
        {
            // Arrange
            short commandsCount = this._maxCommandsCount;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} {99}";
            }
            int expectedResult = 100;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }
     
        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_10000Times_1000UniqueCleans()
        {
            // Arrange
            short commandsCount = this._maxCommandsCount;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} {999}";
            }
            int expectedResult = 1000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }
                
        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_10000Times_10000UniqueCleans()
        {
            // Arrange
            short commandsCount = this._maxCommandsCount;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} {9999}";
            }
            int expectedResult = 10000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_10000Times_20000UniqueCleans()
        {
            // Arrange
            short commandsCount = this._maxCommandsCount;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} {19999}";
            }
            int expectedResult = 20000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }

        [Fact]
        public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_10000Times_50000UniqueCleans()
        {
            // Arrange
            short commandsCount = this._maxCommandsCount;
            string startingCoordinates = this._centerCoordinates;
            string[] movementCommands = new string[commandsCount];
            string direction = "E";
            for (int i = 0; i < commandsCount; i++)
            {
                direction = (direction == "E" ? "W" : "E");
                movementCommands[i] = $"{direction} {49999}";
            }
            int expectedResult = 50000;

            //Act
            int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

            // Assert
            Assert.Equal(expectedResult, cleanedPoints);
        }
       
        //[Fact]
        //public void GetUniqueCleanedPoints_FromCenterToEast_ReturnWest_10000Times_100000UniqueCleans()
        //{
        //    // Arrange
        //    short commandsCount = this._maxCommandsCount;
        //    string startingCoordinates = this._centerCoordinates;
        //    string[] movementCommands = new string[commandsCount];
        //    string direction = "E";
        //    for (int i = 0; i < commandsCount; i++)
        //    {
        //        direction = (direction == "E" ? "W" : "E");
        //        movementCommands[i] = $"{direction} {this._maxStep}";
        //    }
        //    int expectedResult = 100000;

        //    //Act
        //    int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

        //    // Assert
        //    Assert.Equal(expectedResult, cleanedPoints);
        //}

        #endregion /Max Repetitive Path

        #region Max Straight Path

        //[Fact]
        //public void GetUniqueCleanedPoints_FromNorthEastToEast_10000Times_1BillionUniqueCleans() // 1,000,000,000
        //{
        //    // Arrange
        //    short commandsCount = 100; // this._maxCommandsCount
        //    string startingCoordinates = this._northEastCoordinates;
        //    string[] movementCommands = new string[commandsCount];
        //    for (int i = 0; i < commandsCount; i++)
        //    {
        //        movementCommands[i] = $"E {this._maxStep}";
        //    }
        //    int expectedResult = Math.Pow(10, 9); // 1,000,000,000

        //    //Act
        //    int cleanedPoints = this._cleanerService.GetUniqueCleanedPoints(startingCoordinates, movementCommands);

        //    // Assert
        //    Assert.Equal(expectedResult, cleanedPoints);
        //}
        
        #endregion /Max Straight Path

        #endregion /Methods

    }
}
