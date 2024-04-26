namespace Umeliko.Domain.Learning.Factories.Materials;

using Models.Materials;

internal class MaterialFactory : IMaterialFactory
{
    private ContentType materialContentType = default!;
    private StateType materialStateType = default!;

    public IMaterialFactory WithContentType(ContentType contentType)
    {
        this.materialContentType = contentType;

        return this;
    }

    public IMaterialFactory WithStateType(StateType stateType)
    {
        this.materialStateType = stateType;

        return this;
    }

    public Material Build() => new Material(this.materialContentType, this.materialStateType);
}
