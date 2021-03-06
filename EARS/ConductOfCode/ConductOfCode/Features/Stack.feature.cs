﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ConductOfCode.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Stack<T>")]
    public partial class StackTFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Stack.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Stack<T>", "\tIn order to store instances of the same specified type in last-in-first-out (LIF" +
                    "O) sequence\r\n\tAs a developer\r\n\tI want to use a Stack<T>", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The Stack<T> shall store instances of the same specified type in last-in-first-ou" +
            "t (LIFO) order")]
        [NUnit.Framework.CategoryAttribute("Ubiquitous")]
        public virtual void TheStackTShallStoreInstancesOfTheSameSpecifiedTypeInLast_In_First_OutLIFOOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The Stack<T> shall store instances of the same specified type in last-in-first-ou" +
                    "t (LIFO) order", new string[] {
                        "Ubiquitous"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("an empty stack", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table1.AddRow(new string[] {
                        "One"});
            table1.AddRow(new string[] {
                        "Two"});
            table1.AddRow(new string[] {
                        "Three"});
#line 10
 testRunner.When("the pushing the elements:", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table2.AddRow(new string[] {
                        "Three"});
            table2.AddRow(new string[] {
                        "Two"});
            table2.AddRow(new string[] {
                        "One"});
#line 15
 testRunner.Then("the elements should be popped in the order:", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The Stack<T> shall return the number of elements contained when the property Coun" +
            "t is invoked")]
        [NUnit.Framework.CategoryAttribute("Ubiquitous")]
        public virtual void TheStackTShallReturnTheNumberOfElementsContainedWhenThePropertyCountIsInvoked()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The Stack<T> shall return the number of elements contained when the property Coun" +
                    "t is invoked", new string[] {
                        "Ubiquitous"});
#line 22
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table3.AddRow(new string[] {
                        "One"});
            table3.AddRow(new string[] {
                        "Two"});
            table3.AddRow(new string[] {
                        "Three"});
#line 23
 testRunner.Given("a stack with the elements:", ((string)(null)), table3, "Given ");
#line 28
 testRunner.When("counting the elements", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("the result should be 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When the method Push is invoked, the Stack<T> shall inserts the element at the to" +
            "p")]
        [NUnit.Framework.CategoryAttribute("EventDriven")]
        public virtual void WhenTheMethodPushIsInvokedTheStackTShallInsertsTheElementAtTheTop()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When the method Push is invoked, the Stack<T> shall inserts the element at the to" +
                    "p", new string[] {
                        "EventDriven"});
#line 32
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table4.AddRow(new string[] {
                        "One"});
            table4.AddRow(new string[] {
                        "Two"});
            table4.AddRow(new string[] {
                        "Three"});
#line 33
 testRunner.Given("a stack with the elements:", ((string)(null)), table4, "Given ");
#line 38
 testRunner.When("pushing the element \"Four\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("the element \"Four\" should be on top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When the method Pop is invoked, the Stack<T> shall remove and return the element " +
            "at the top")]
        [NUnit.Framework.CategoryAttribute("EventDriven")]
        public virtual void WhenTheMethodPopIsInvokedTheStackTShallRemoveAndReturnTheElementAtTheTop()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When the method Pop is invoked, the Stack<T> shall remove and return the element " +
                    "at the top", new string[] {
                        "EventDriven"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table5.AddRow(new string[] {
                        "One"});
            table5.AddRow(new string[] {
                        "Two"});
            table5.AddRow(new string[] {
                        "Three"});
#line 43
 testRunner.Given("a stack with the elements:", ((string)(null)), table5, "Given ");
#line 48
 testRunner.When("popping the element on top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
 testRunner.Then("the result should be \"Three\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
 testRunner.And("the element \"Two\" should be on top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When the method Peek is invoked, the Stack<T> shall return the element at the top" +
            " without removing it")]
        [NUnit.Framework.CategoryAttribute("EventDriven")]
        public virtual void WhenTheMethodPeekIsInvokedTheStackTShallReturnTheElementAtTheTopWithoutRemovingIt()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When the method Peek is invoked, the Stack<T> shall return the element at the top" +
                    " without removing it", new string[] {
                        "EventDriven"});
#line 53
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table6.AddRow(new string[] {
                        "One"});
            table6.AddRow(new string[] {
                        "Two"});
            table6.AddRow(new string[] {
                        "Three"});
#line 54
 testRunner.Given("a stack with the elements:", ((string)(null)), table6, "Given ");
#line 59
 testRunner.When("peeking at the element on top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.Then("the result should be \"Three\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
 testRunner.And("the element \"Three\" should be on top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("While an element is present, the Stack<T> shall return true when the method Conta" +
            "ins is invoked")]
        [NUnit.Framework.CategoryAttribute("StateDriven")]
        public virtual void WhileAnElementIsPresentTheStackTShallReturnTrueWhenTheMethodContainsIsInvoked()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("While an element is present, the Stack<T> shall return true when the method Conta" +
                    "ins is invoked", new string[] {
                        "StateDriven"});
#line 64
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table7.AddRow(new string[] {
                        "One"});
            table7.AddRow(new string[] {
                        "Two"});
            table7.AddRow(new string[] {
                        "Three"});
#line 65
 testRunner.Given("a stack with the elements:", ((string)(null)), table7, "Given ");
#line 70
 testRunner.When("determining if the stack contains the element \"Three\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
 testRunner.Then("the result should be true", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("While an element is not present, the Stack<T> shall return false when the method " +
            "Contains is invoked")]
        [NUnit.Framework.CategoryAttribute("StateDriven")]
        public virtual void WhileAnElementIsNotPresentTheStackTShallReturnFalseWhenTheMethodContainsIsInvoked()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("While an element is not present, the Stack<T> shall return false when the method " +
                    "Contains is invoked", new string[] {
                        "StateDriven"});
#line 74
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table8.AddRow(new string[] {
                        "One"});
            table8.AddRow(new string[] {
                        "Two"});
            table8.AddRow(new string[] {
                        "Three"});
#line 75
 testRunner.Given("a stack with the elements:", ((string)(null)), table8, "Given ");
#line 80
 testRunner.When("determining if the stack contains the element \"Four\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
 testRunner.Then("the result should be false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("If empty and the method Pop is invoked, then the Stack<T> shall throw InvalidOper" +
            "ationException")]
        [NUnit.Framework.CategoryAttribute("UnwantedBehavior")]
        public virtual void IfEmptyAndTheMethodPopIsInvokedThenTheStackTShallThrowInvalidOperationException()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If empty and the method Pop is invoked, then the Stack<T> shall throw InvalidOper" +
                    "ationException", new string[] {
                        "UnwantedBehavior"});
#line 84
this.ScenarioSetup(scenarioInfo);
#line 85
 testRunner.Given("an empty stack", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 86
 testRunner.When("popping the element on top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.Then("InvalidOperationException should be thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("If empty and the method Peek is invoked, then the Stack<T> shall throw InvalidOpe" +
            "rationException")]
        [NUnit.Framework.CategoryAttribute("UnwantedBehavior")]
        public virtual void IfEmptyAndTheMethodPeekIsInvokedThenTheStackTShallThrowInvalidOperationException()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If empty and the method Peek is invoked, then the Stack<T> shall throw InvalidOpe" +
                    "rationException", new string[] {
                        "UnwantedBehavior"});
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
 testRunner.Given("an empty stack", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.When("peeking at the element on top", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.Then("InvalidOperationException should be thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Where instantiated with a specified collection, the Stack<T> shall be pre-populat" +
            "ed with the elements of the collection")]
        [NUnit.Framework.CategoryAttribute("Optional")]
        public virtual void WhereInstantiatedWithASpecifiedCollectionTheStackTShallBePre_PopulatedWithTheElementsOfTheCollection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Where instantiated with a specified collection, the Stack<T> shall be pre-populat" +
                    "ed with the elements of the collection", new string[] {
                        "Optional"});
#line 96
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table9.AddRow(new string[] {
                        "One"});
            table9.AddRow(new string[] {
                        "Two"});
            table9.AddRow(new string[] {
                        "Three"});
#line 97
 testRunner.Given("a stack with the elements:", ((string)(null)), table9, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Element"});
            table10.AddRow(new string[] {
                        "Three"});
            table10.AddRow(new string[] {
                        "Two"});
            table10.AddRow(new string[] {
                        "One"});
#line 102
 testRunner.Then("the stack should contain the elements:", ((string)(null)), table10, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
