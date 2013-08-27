﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDepend;
using NDepend.Path;
using NDepend.Analysis;
using NDepend.Project;
using NDepend.CodeModel;
using NDepend.PowerTools;

namespace NDependMetricsTrendCharts
{
    class CodeBaseManager
    {
        IProject nDependProject;

        public CodeBaseManager(IProject nDependProject)
        {
            this.nDependProject = nDependProject;
        }

        public ICodeBase LoadLastCodebase()
        {
            IAnalysisResultRef lastAnalysisResultRef;
            bool result = nDependProject.TryGetMostRecentAnalysisResultRef(out lastAnalysisResultRef);
            IAnalysisResult analisysResult = lastAnalysisResultRef.Load();
            ICodeBase codeBase = analisysResult.CodeBase;
            return codeBase;
        }

        public ICodeBase LoadCodeBase(IAnalysisResultRef analysisResultRef)
        {
            IAnalysisResult currentAnalysisResult = analysisResultRef.Load();
            return currentAnalysisResult.CodeBase;
        }
    }
}
