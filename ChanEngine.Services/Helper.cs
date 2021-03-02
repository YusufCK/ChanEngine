using System;
using System.Collections.Generic;
using System.Text;

namespace ChanEngine.Services
{
    public static class Helper
    {
        public static PatchValues[] GetPatchValues(string quantity)
        {
            var patchValues = new PatchValues[]
            {
                new PatchValues
                {
                    Op = "replace",
                    Path = "stock",
                    Value = quantity
                }
            };
            return patchValues;
        }
    }

    public class PatchValues
    {
        public string Op { get; set; }
        public string Value { get; set; }
        public string Path { get; set; }
    }
}
