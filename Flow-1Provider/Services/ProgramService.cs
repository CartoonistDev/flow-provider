using Flow_1Provider.data;
using Flow_1Provider.Interface;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Flow_1Provider.Infrastructure.Services
{
    public class ProgramService : IProgramService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly IConfiguration _config;
        private readonly Container programContainer;
        public ProgramService(CosmosClient cosmosClient, IConfiguration config)
        {
            _cosmosClient = cosmosClient;
            _config = config;
            var databaseID = _config["ConnectionStrings:DatabaseId"];
            var programContainerName = "Programs";
            programContainer = _cosmosClient.GetContainer(databaseID, programContainerName);
        }

        public async Task<Programs> GetById(string programId)
        {

            var query = programContainer.GetItemLinqQueryable<Programs>()
            .Where(t => t.id == programId)
            .Take(1)
            .ToQueryDefinition();

            var sqlQuery = query.QueryText; // Retrieve the SQL query

            var response = await programContainer.GetItemQueryIterator<Programs>(query).ReadNextAsync();
            return response.FirstOrDefault();
        }

        public async Task<dynamic> Add(Programs program)
        {
            try
            {
                var addProgram = await programContainer.CreateItemAsync(program);

                if (addProgram == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Programs> Update(Programs updatedProgram)
        {
            Programs existingProgram = new();

            try
            {
                // Find the existing program based on the ProgramsId
                var query = programContainer.GetItemLinqQueryable<Programs>()
                    .Where(t => t.id == updatedProgram.ProgramsId)  // Assuming Id is the correct property
                    .Take(1)
                    .ToQueryDefinition();

                var response = await programContainer.GetItemQueryIterator<Programs>(query).ReadNextAsync();
                existingProgram = response.FirstOrDefault();

                if (existingProgram != null)
                {
                    // Update the properties of the existing program
                    existingProgram.Summary = updatedProgram.Summary;
                    existingProgram.Description = updatedProgram.Description;
                    existingProgram.Skills = updatedProgram.Skills;
                    existingProgram.Benefits = updatedProgram.Benefits;
                    existingProgram.ApplicationClose = updatedProgram.ApplicationClose;
                    existingProgram.ApplicationCriteria = updatedProgram.ApplicationCriteria;
                    existingProgram.ApplicationOpen = updatedProgram.ApplicationOpen;
                    existingProgram.NumberOfApplicants = updatedProgram.NumberOfApplicants;
                    existingProgram.StartDate = updatedProgram.StartDate;
                    existingProgram.Location = updatedProgram.Location;
                    existingProgram.MinQualification = updatedProgram.MinQualification;
                    existingProgram.Duration = updatedProgram.Duration;
                    existingProgram.ProgramType = updatedProgram.ProgramType;
                    existingProgram.UserId = updatedProgram.UserId;
                    existingProgram.AppTemplate = updatedProgram.AppTemplate;
                    existingProgram.Stages = updatedProgram.Stages;

                    // Upsert the updated program document in Cosmos DB
                    var upsertedProgram = await programContainer.UpsertItemAsync(existingProgram);

                    return upsertedProgram.Resource;
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log or rethrow)
            }

            return existingProgram;
        }

        public async Task<AppTemplate> UpdateApplicationForm(AppTemplate appTemplate)
        {
            AppTemplate app = new();
            try
            {
                var query = programContainer.GetItemLinqQueryable<Programs>()
                                .Where(t => t.id == appTemplate.ProgramsId)
                                .Take(1)
                                .ToQueryDefinition();

                var sqlQuery = query.QueryText; // Retrieve the SQL query

                var response = await programContainer.GetItemQueryIterator<Programs>(query).ReadNextAsync();
                Programs program = response.FirstOrDefault();

                if (program != null)
                {
                    program.AppTemplate = new()
                    {
                        CoverImage = appTemplate.CoverImage,
                        CurrentResidence = appTemplate.CurrentResidence,
                        DateOfBirth = appTemplate.DateOfBirth,
                        Education = appTemplate.Education,
                        Email = appTemplate.Email,
                        FirstName = appTemplate.FirstName,
                        LastName = appTemplate.LastName,
                        Gender = appTemplate.Gender,
                        IdNumber = appTemplate.IdNumber,
                        Nationality = appTemplate.Nationality,
                        PhoneNumber = appTemplate.PhoneNumber,
                        Questions = appTemplate.Questions,
                        Resume = appTemplate.Resume,
                        WorkExperience = appTemplate.WorkExperience
                    };


                    var updateProgram = await programContainer.UpsertItemAsync(program);

                    app = updateProgram.Resource.AppTemplate;
                }
            }
            catch (Exception ex)
            {

            }
            return app;
        }

        public async Task<List<Stage>> UpdateWorkFlow(List<Stage> stage, string ProgramsId)
        {
            List<Stage> stageList = new();
            try
            {
                var query = programContainer.GetItemLinqQueryable<Programs>()
                                .Where(t => t.id == ProgramsId)
                                .Take(1)
                                .ToQueryDefinition();

                var sqlQuery = query.QueryText; // Retrieve the SQL query

                var response = await programContainer.GetItemQueryIterator<Programs>(query).ReadNextAsync();
                Programs program = response.FirstOrDefault();

                if (program != null)
                {

                    //Create a new list to store the updated stages
                    List<Stage> updatedStages = new();

                    foreach (var updatedStage in stage)
                    {
                        // Find the corresponding stage in the updatedProgram.Stages list by Id
                        var existingStage = program.Stages.FirstOrDefault(s => s.id == updatedStage.id);

                        // If a corresponding stage is found, update its properties
                        if (existingStage != null)
                        {
                            existingStage.Name = updatedStage.Name;
                            existingStage.ShowCandidate = updatedStage.ShowCandidate;
                            existingStage.StageType = updatedStage.StageType;

                            // Add the updated stage to the list
                            updatedStages.Add(existingStage);
                        }
                        else
                        {
                            // If the corresponding stage is not found, add the original stage to the list
                            updatedStages.Add(updatedStage);
                        }
                    }

                    // Update the program with the updated stages
                    program.Stages = updatedStages;

                    var updateProgram = await programContainer.UpsertItemAsync(program);

                    stageList = updateProgram.Resource.Stages;

                }
            }
            catch (Exception ex)
            {
            }

            return stageList;
        }
    }
}
