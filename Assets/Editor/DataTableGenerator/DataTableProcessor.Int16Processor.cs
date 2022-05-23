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
        private sealed class Int16Processor : GenericDataProcessor<short>
        {
            public override bool IsSystem => true;
            public override string LanguageKeyword => "short";
            public override string ExtensionParseKey => "ParseShort";

            public override string[] GetTypeStrings()
            {
                return new string[]
                {
                    "short",
                    "int16",
                    "system.int16"
                };
            }

            public override short Parse(string value)
            {
                bool isParse = short.TryParse(value, out short result);
                return isParse ? result : (short)0;
            }

            public override void WriteToStream(DataTableProcessor dataTableProcessor, BinaryWriter binaryWriter, string value)
            {
                binaryWriter.Write(Parse(value));
            }
        }
    }
}
