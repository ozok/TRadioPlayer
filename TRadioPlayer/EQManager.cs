using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRadioPlayer
{
    public class EqManager
    {
        private Process _process = null;

        public EqManager(Process process)
        {
            _process = process;
        }

        public string GenerateApplyEqCmd(double[] eqValues)
        {
            string eqCmd = "";
            if (eqValues.Length == 10)
            {
                eqCmd = "--af-add=equalizer=";
                for (int i = 0; i < eqValues.Length; i++)
                {
                    if (i != eqValues.Length-1)
                    {
                        eqCmd += (eqValues[i]/100.0).ToString() + ":";
                    }
                    else
                    {
                        eqCmd += (eqValues[i] / 100.0).ToString();
                    }
                }
            }
            return eqCmd;
        }
    }
}
