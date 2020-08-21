using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallTwo
{
    class ChallTwo_ClaimContent
    {
        public ChallTwo_ClaimContent() { }

        public ChallTwo_ClaimContent(int claimIDNumber, ClaimType claimType, string claimDescription, decimal claimAmount, DateTime claimAccidentDate, DateTime claimFileDate, bool claimIsValid)
        {
            ClaimIDNumber = claimIDNumber;
            ClaimType = claimType;
            ClaimDesc = claimDescription;
            ClaimAmount = claimAmount;
            ClaimAccidentDate = claimAccidentDate;
            ClaimFiledDate = claimFileDate;
            ClaimIsValid = claimIsValid;
        }
        public int ClaimIDNumber { get; set; }
        public ClaimType ClaimType { get; set; }
        public string ClaimDesc { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime ClaimAccidentDate { get; set; }
        public DateTime ClaimFiledDate { get; set; }
        public bool ClaimIsValid { get; set; }

    }
    public enum ClaimType
    {
        Car, Home, Theft
    }
}
