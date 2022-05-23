//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.IO;

namespace Meland.Editor.DataTableTools
{
    public sealed partial class DataTableProcessor
    {
        private sealed class DoubleProcessor : GenericDataProcessor<double>
        {
            public override bool IsSystem => true;

            public override string LanguageKeyword => "double";
            public override string ExtensionParseKey => "ParseDouble";

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "float",
                    "double",
                    "system.double"
                };
            }

            public override double Parse(string value)
            {
                bool isParse = double.TryParse(value, out double result);
                return isParse ? result : 0;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                binaryWriter.Write(Parse(value));
            }
        }
    }
}
