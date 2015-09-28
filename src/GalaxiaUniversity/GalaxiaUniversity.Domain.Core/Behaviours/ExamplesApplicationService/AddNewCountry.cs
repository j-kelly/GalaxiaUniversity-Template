namespace GalaxiaUniversity.Domain.Core.Behaviours.ExamplesApplicationService
{

    using GalaxiaUniversity.Core.Domain;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using GalaxiaUniversity.Core.Domain.InvariantValidation;
    using System.ComponentModel.DataAnnotations;

    public class AddNewCountry
    {
        //
        // AddNewCountry.CommandModel
        //
        public class CommandModel
        {
            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string Name { get; set; }

            [Range(1, int.MaxValue)]
            public int Population { get; set; }
        }

        //
        // AddNewCountry.Request
        //
        public class Request : DomainRequest<CommandModel>
        {
            public Request(string userId, CommandModel commandModel)
                : base(userId, commandModel)
            {
                InvariantValidation = new InvariantValidation(this);
                ContextualValidation = new ContextualValidation(this);
            }
        }

        //
        // AddNewCountry.Response
        //
        public class Response : DomainResponse
        {
            public Response(int? id = null, ValidationMessageCollection validationDetails = null)
                : base(validationDetails)
            {
                Id = id;
            }

            public int? Id { get; }
        }

        //
        // AddNewCountry.InvariantValidation
        //
        public class InvariantValidation : UserDomainRequestInvariantValidation<Request, CommandModel>
        {
            public InvariantValidation(Request context)
                : base(context)
            {
            }
        }

        //
        // AddNewCountry.ContextualValidation
        //
        public class ContextualValidation : ContextualValidation<Request, CommandModel>
        {
            public ContextualValidation(Request context)
                : base(context)
            {
            }

            public override void Validate()
            {
                if (Context.CommandModel.Name == "China" && Context.CommandModel.Population < 10)
                    Validate(false, nameof(Context.CommandModel.Population), "Really? I think we all know China has a bigger population than that.");
            }
        }
    }
}
