namespace DarkOnix.Identity.Api.Models;

public sealed class SuccessModel
{
    public bool Succeeded => true;

    private SuccessModel() {}

    private readonly static SuccessModel _instance = new();

    public static SuccessModel Instance => _instance;
}
