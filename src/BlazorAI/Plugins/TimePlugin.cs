using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace BlazorAI.Plugins {
    public class TimePlugin {
        [KernelFunction("get_time")]
        [Description("Returns the current time.")]
        [return: Description("The current time.")]
        public string GetTime() {
            Console.WriteLine("Getting Current Time");
            return DateTime.Now.ToString("h:mm tt 'on' MMMM dd, yyyy");
        }

        [KernelFunction("get_relative_date")]
        [Description("Returns a past or future date relative to the parameters.")]
        [return: Description("The relative date.")]
        public string GetRelativeDate(int days, int months, int years) {
            Console.WriteLine("Getting Future/Past Date");
            return DateTime.Now.AddDays(days).AddMonths(months).AddYears(years).ToString("MMMM dd, yyyy");
        }
    }
}