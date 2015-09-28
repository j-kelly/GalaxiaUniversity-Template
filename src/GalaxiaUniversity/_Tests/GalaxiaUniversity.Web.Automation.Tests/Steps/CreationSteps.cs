namespace GalaxiaUniversity.Web.Automation.Tests.Steps.Behaviours
{
    using TechTalk.SpecFlow;

    [Binding]
    public class CreationSteps
    {
        //[Given(@"I have the following departments")]
        //public void GivenIHaveTheFollowingDepartments(Table table)
        //{
        //    using (var repository = new GalaxiaUniversityEntityFrameworkRepository())
        //    {
        //        foreach (var row in table.Rows)
        //        {
        //            var commandModel = DataHelper.CreateCommandModelFromTable<CreateDepartment.CommandModel>(table, row);
        //            var response = new DepartmentApplicationService(repository).CreateDepartment(
        //                new CreateDepartment.Request(
        //                "test",
        //                commandModel));

        //            if (response.HasValidationIssues)
        //                throw new ApplicationException(string.Join(" | ", response.ValidationDetails.Select(p => p.ErrorMessage)));

        //            DataHelper.AddEntityToRemove(EntityType.Department, response.DepartmentId);
        //        }
        //    }
        //}
    }
}
