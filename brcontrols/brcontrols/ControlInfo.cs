using System;

namespace brcontrols
{
    public class ControlInfo
    {
        public string Name
        {
            get
            {
                return Enum.GetName(typeof(ControlType), Type); 
            } 
        }

        public ControlType Type { get; set; }
    }
}
