using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCliCodeSnippets
{
    public interface ICodeSnippet
    {
        void Execute();
        System.Threading.Tasks.Task ExecuteAsync();
    }
}
