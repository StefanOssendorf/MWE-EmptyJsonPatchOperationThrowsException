using System;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MWE_JsonPatchApplyToException.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpPatch]
        public ActionResult<Foo> Patch([FromBody] JsonPatchDocument<Foo> patchDocument)
        {
            var origFoo = new Foo { Name = "Dummy" };

            patchDocument.ApplyTo(origFoo, ModelState); // This should not throw any exception!
            if ( !ModelState.IsValid )
            {
                return ValidationProblem();
            }

            return Ok(origFoo);
        }
    }

    public class Foo
    {
        public String Name { get; set; }
    }
}
