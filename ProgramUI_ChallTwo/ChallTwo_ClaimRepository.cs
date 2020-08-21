using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramUI_ChallTwo
{
    class ClaimRepository
    {
        private Queue<ChallTwo_ClaimContent> _claimLibrary = new Queue<ChallTwo_ClaimContent>();

        // Create
        public void AddClaim(ChallTwo_ClaimContent content)
        {
            _claimLibrary.Enqueue(content);
        }

        // Read

        public Queue<ChallTwo_ClaimContent> GetDirectory()
        {
            return _claimLibrary;
        }

        // Update
        public void UpdateClaim(ChallTwo_ClaimContent content)
        {
            _claimLibrary.Clear();
            _claimLibrary.Enqueue(content);
        }

        // Delete

        public void RemoveClaim()
        {
            _claimLibrary.Dequeue();
        }
    }
}
