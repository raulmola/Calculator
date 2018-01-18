/* Options:
Date: 2018-01-18 15:55:23
Version: 5,02
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: http://127.0.0.1:8088

//GlobalNamespace: 
//MakePartial: True
//MakeVirtual: True
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: False
//AddIndexesToDataMembers: False
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: True
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: http://schemas.servicestack.net/types
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using CalculatorService.ServiceModel;


namespace CalculatorService.ServiceModel
{

    [Route("/calculator/add/")]
    public partial class Add
        : IReturn<AddResponse>
    {
        public Add()
        {
            Addends = new int[]{};
        }

        public virtual int[] Addends { get; set; }
    }

    public partial class AddResponse
    {
        public virtual int Sum { get; set; }
    }

    [Route("/calculator/div/")]
    public partial class Divide
        : IReturn<DivideResponse>
    {
        public virtual int Dividend { get; set; }
        public virtual int Divisor { get; set; }
    }

    public partial class DivideResponse
    {
        public virtual int Quotient { get; set; }
        public virtual int Reminder { get; set; }
    }

    [Route("/calculator/mul/")]
    public partial class Multiply
        : IReturn<MultiplyResponse>
    {
        public Multiply()
        {
            Factors = new int[]{};
        }

        public virtual int[] Factors { get; set; }
    }

    public partial class MultiplyResponse
    {
        public virtual int Product { get; set; }
    }

    public partial class OperationItem
    {
        public virtual string Operation { get; set; }
        public virtual string Calculation { get; set; }
        public virtual string Date { get; set; }
    }

    [Route("/calculator/query/")]
    public partial class Query
        : IReturn<QueryResponse>
    {
        public virtual string Id { get; set; }
    }

    public partial class QueryResponse
    {
        public QueryResponse()
        {
            Operations = new OperationItem[]{};
        }

        public virtual OperationItem[] Operations { get; set; }
    }

    [Route("/calculator/sqrt/")]
    public partial class SquareRoot
        : IReturn<SquareRootResponse>
    {
        public virtual int Number { get; set; }
    }

    public partial class SquareRootResponse
    {
        public virtual int Square { get; set; }
    }

    public partial class Substract
        : IReturn<SubstractResponse>
    {
        public virtual int Minuend { get; set; }
        public virtual int Substrahend { get; set; }
    }

    public partial class SubstractResponse
    {
        public virtual int Difference { get; set; }
    }
}

