﻿using SolrExpress.Core;
using SolrExpress.Core.Search;
using SolrExpress.Core.Search.Parameter;
using SolrExpress.Core.Utility;
using System.Collections.Generic;

namespace SolrExpress.Solr4.Search.Parameter
{
    /// <summary>
    /// Signatures to use boost parameter
    /// </summary>
    public class BoostParameter<TDocument> : BaseBoostParameter<TDocument>, ISearchParameterExecute<List<string>>
        where TDocument : IDocument
    {
        public BoostParameter(IExpressionBuilder<TDocument> expressionBuilder)
            : base(expressionBuilder)
        {
        }

        /// <summary>
        /// Execute the creation of the parameter
        /// </summary>
        /// <param name="container">Container to parameters to request to SOLR</param>
        public void Execute(List<string> container)
        {
            var boostFunction = this.BoostFunctionType.ToString().ToLower();
            container.Add($"{boostFunction}={this.Query.Execute()}");
        }
    }
}
