using Bliss.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.States.Summary
{
    public partial class SummaryState : State
    {
        public static string Name = "Summary";

        PlayerStats PlayerStats { get; set; }

        protected override void OnLoad(params object[] parameter)
        {
            PlayerStats = (PlayerStats)parameter[0];

            if (PlayerStats.WronglyEndedCalls > 0) PlayerStats.Warnings++;
            if (PlayerStats.WronglySortedDocuments >= 5) PlayerStats.Warnings++;
            if (PlayerStats.MissedCalls >= 1) PlayerStats.Warnings++;
            if (PlayerStats.DocumentsLeft >= 10) PlayerStats.Warnings++;
        }
    }
}
