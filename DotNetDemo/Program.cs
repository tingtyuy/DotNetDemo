// See https://aka.ms/new-console-template for more information
using DotNetDemo.DataTableModule;
using Dumpify;
using System.Data;

var dtA=DataTableModule.CreateTable(null);
var dtB=DataTableModule.CreateTable(null);
dtA.Merge(dtB,false, MissingSchemaAction.AddWithKey);
dtA.DumpConsole();