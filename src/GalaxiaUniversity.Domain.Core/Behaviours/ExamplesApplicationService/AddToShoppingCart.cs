namespace GalaxiaUniversity.Domain.Core.Behaviours.ExamplesApplicationService
{

    using GalaxiaUniversity.Core.Domain;
    using GalaxiaUniversity.Core.Domain.ContextualValidation;
    using GalaxiaUniversity.Core.Domain.InvariantValidation;
    using NRepository.Core;
    using System.ComponentModel.DataAnnotations;

    public class AddToShoppingCart
    {
        //
        // AddToShoppingCart.CommandModel
        //
        public class CommandModel
        {
            [Required]
            [StringLength(50, MinimumLength = 3)]
            public string DummyValue { get; set; }
        }

        //
        // AddToShoppingCart.Request
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
        // AddToShoppingCart.Response
        //
        public class Response : DomainResponse
        {
            public Response()
            {
            }

            public Response(ValidationMessageCollection validationDetails)
                : base(validationDetails)
            {
            }
        }

        //
        // AddToShoppingCart.InvariantValidation
        //
        public class InvariantValidation : UserDomainRequestInvariantValidation<Request, CommandModel>
        {
            public InvariantValidation(Request context)
                : base(context)
            {
            }
        }

        //
        // AddToShoppingCart.ContextualValidation
        //
        public class ContextualValidation : ContextualValidation<Request, CommandModel>
        {
            public ContextualValidation(Request context)
                : base(context)
            {
            }
        }
    }

}
