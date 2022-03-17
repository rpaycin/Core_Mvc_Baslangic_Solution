using System;

namespace App.Core.Dto
{
    public class ParamGenDto: BaseDto
    {
        public int ParameterId { get; set; }
        public string Value { get; set; }
        public bool Isactive { get; set; }
    }
}
