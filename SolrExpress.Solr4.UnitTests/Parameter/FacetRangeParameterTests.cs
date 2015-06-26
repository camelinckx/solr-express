﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolrExpress.Core.Enumerator;
using SolrExpress.Solr4.Parameter;

namespace SolrExpress.Solr4.UnitTests.Parameter
{
    [TestClass]
    public class FacetRangeParameterTests
    {
        /// <summary>
        /// Where   Using a FacetRangeParameter instance
        /// When    Invoking the method "Execute" using the default arguments
        /// What    Create a valid string
        /// </summary>
        [TestMethod]
        public void FacetRangeParameter001()
        {
            // Arrange
            var container = new List<string>();
            var parameter = new FacetRangeParameter<TestDocument>(q => q.Id, "X", "1", "10", "20");

            // Act
            parameter.Execute(container);

            // Assert
            Assert.AreEqual(8, container.Count);
            Assert.AreEqual("facet=true", container[0]);
            Assert.AreEqual("facet.range={!ex=dt key=X}Id", container[1]);
            Assert.AreEqual("f.Id.facet.range.gap=1", container[2]);
            Assert.AreEqual("f.Id.facet.range.start=10", container[3]);
            Assert.AreEqual("f.Id.facet.range.end=20", container[4]);
            Assert.AreEqual("f.Id.facet.range.other=before", container[5]);
            Assert.AreEqual("f.Id.facet.range.other=after", container[6]);
            Assert.AreEqual("f.Id.facet.mincount=1", container[7]);
        }

        /// <summary>
        /// Where   Using a FacetRangeParameter instance
        /// When    Invoking the method "Execute" using the sort type and direction parameters
        /// What    Create a valid string
        /// </summary>
        [TestMethod]
        public void FacetRangeParameter002()
        {
            // Arrange
            var container = new List<string>();
            var parameter = new FacetRangeParameter<TestDocument>(q => q.Id, "X", "1", "10", "20", SolrFacetSortType.CountDesc);

            // Act
            parameter.Execute(container);

            // Assert
            Assert.AreEqual(9, container.Count);
            Assert.AreEqual("facet=true", container[0]);
            Assert.AreEqual("facet.range={!ex=dt key=X}Id", container[1]);
            Assert.AreEqual("f.Id.facet.range.gap=1", container[2]);
            Assert.AreEqual("f.Id.facet.range.start=10", container[3]);
            Assert.AreEqual("f.Id.facet.range.end=20", container[4]);
            Assert.AreEqual("f.Id.facet.range.other=before", container[5]);
            Assert.AreEqual("f.Id.facet.range.other=after", container[6]);
            Assert.AreEqual("f.Id.facet.range.sort=count", container[7]);
            Assert.AreEqual("f.Id.facet.mincount=1", container[8]);
        }
    }
}