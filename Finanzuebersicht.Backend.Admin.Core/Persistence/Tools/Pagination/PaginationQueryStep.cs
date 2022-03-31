using System.Collections.Generic;

namespace Finanzuebersicht.Backend.Admin.Core.Persistence.Tools.Pagination
{
    internal class PaginationQueryStep
    {
        public PaginationQueryStepType PaginationQueryStepType { get; set; }

        public string Name { get; set; }

        public static PaginationQueryStep[] Parse(string propertyQuery)
        {
            string queryString = propertyQuery
                    .Split('=')[1]
                    .Trim();

            List<PaginationQueryStep> querySteps = new List<PaginationQueryStep>();

            var currentString = string.Empty;
            var currentStepType = PaginationQueryStepType.Property;
            if (queryString[0] == '<')
            {
                currentStepType = PaginationQueryStepType.Any;
                queryString = queryString[1..];
            }

            foreach (var queryChar in queryString)
            {
                switch (queryChar)
                {
                    case '<':
                        querySteps.Add(new PaginationQueryStep()
                        {
                            Name = currentString.Trim(),
                            PaginationQueryStepType = currentStepType,
                        });
                        currentStepType = PaginationQueryStepType.Any;
                        currentString = string.Empty;
                        break;

                    case '.':
                        querySteps.Add(new PaginationQueryStep()
                        {
                            Name = currentString.Trim(),
                            PaginationQueryStepType = currentStepType,
                        });
                        currentStepType = PaginationQueryStepType.Property;
                        currentString = string.Empty;
                        break;

                    default:
                        currentString += queryChar;
                        break;
                }
            }

            querySteps.Add(new PaginationQueryStep()
            {
                Name = currentString.Trim(),
                PaginationQueryStepType = PaginationQueryStepType.Final,
            });

            return querySteps.ToArray();
        }
    }
}