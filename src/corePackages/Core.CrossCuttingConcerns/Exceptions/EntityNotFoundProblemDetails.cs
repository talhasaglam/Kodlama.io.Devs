using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class EntityNotFoundProblemDetails : ProblemDetails
{
    public override string ToString() => JsonConvert.SerializeObject(this);
}