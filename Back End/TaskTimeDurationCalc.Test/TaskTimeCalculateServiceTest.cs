using TaskTimeDurationCalc.Services;
using System;
using Xunit;

namespace TaskTimeDurationCalc.Test
{
    public class TaskTimeCalculateServiceTest
    {
        [Fact]
        public void CalculateEndDate_ReturnsEndDate()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 8, 6);
            int workingDays = 5;
            string expectedEndDate = "{\"endDate\":\"06/08/2023\"}";

            // Act
            var calculator = new TaskTimeCalculateService();
            string actualEndDate = calculator.CalculateEndDate(startDate, workingDays);

            // Assert
            Assert.Equal(expectedEndDate, actualEndDate);
        }

        [Fact]
        public void CalculateEndDate_ReturnsStartDate_WorkingDaysIsZero()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 8, 6);
            int workingDays = 0;
            string expectedEndDate = "{\"endDate\":\"06/08/2023\"}";  // Start date should be the same as the end date

            // Act
            var calculator = new TaskTimeCalculateService();
            string actualEndDate = calculator.CalculateEndDate(startDate, workingDays);

            // Assert
            Assert.Equal(expectedEndDate, actualEndDate);
        }

        [Fact]
        public void CalculateEndDate_ReturnsEndDateIgnorHolidays()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 8, 6);
            int workingDays = 7;
            string expectedEndDate = "{\"endDate\":\"06/08/2023\"}";  // Expected end date for the given inputs

            // Act
            var calculator = new TaskTimeCalculateService();
            string actualEndDate = calculator.CalculateEndDate(startDate, workingDays);

            // Assert
            Assert.Equal(expectedEndDate, actualEndDate);
        }
    }
}