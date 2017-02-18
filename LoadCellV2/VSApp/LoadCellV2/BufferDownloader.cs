using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadCellV2
{
    class BufferDownloader
    {
        public delegate void SendRequestDelegate(uint offset, uint size);
     
        public uint Index; // requested index!
        private const uint ChunkSize = 20;
        private const uint TotalSize = 50000;
        private const uint TIMEOUT = 10; //5 ticks

        private uint TimeoutCounter;

        public enum ePHASE { None, Init, SendRequest, WaitAnswer, SendNext, Done };
        public ePHASE Phase = ePHASE.None;

        // statistics
        public int RequestsSent;
        public int AnswersReceived;
        public int Retries;

        public void ExecuteDownloader()
        {
            Phase = ePHASE.Init;
        }

        public void Update(SendRequestDelegate SendRequest)
        {
            switch(Phase)
            {
                case ePHASE.None:
                    break; // do nothing

                case ePHASE.Init:
                    Index = 0;
                    Phase = ePHASE.SendRequest;
                    RequestsSent = 0;
                    AnswersReceived = 0;
                    Retries = 0;
                    break;

                case ePHASE.SendRequest:
                    SendRequest(Index, ChunkSize);
                    Phase = ePHASE.WaitAnswer;
                    RequestsSent++;
                    TimeoutCounter = TIMEOUT;                
                    break;

                case ePHASE.WaitAnswer:
                    // wait    
                    if((TimeoutCounter--) == 0)
                    {
                        // retry
                        Retries++;
                        Phase = ePHASE.SendRequest; // Retry same index
                    }
                    break;

                case ePHASE.SendNext:
                    Index += ChunkSize;
                    if ((Index + ChunkSize) > TotalSize)
                    {
                        Phase = ePHASE.Done; // all done
                    }
                    else
                    {
                        Phase = ePHASE.SendRequest; // send next
                    }

                    break;

                case ePHASE.Done:
                    // do nothing               
                    break;
            }
        }

        public void AnswerReceived()
        {
            if (Phase == ePHASE.WaitAnswer)
            {
                AnswersReceived++;
                Phase = ePHASE.SendNext;
            }
        }

        public void Abort()
        {
            Phase = ePHASE.Done;
        }

        public bool Done()
        {
            return (Phase == ePHASE.Done);
        }
    }
}
