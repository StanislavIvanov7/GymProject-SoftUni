namespace Gym.Core.Models.FitnessCard
{
    public interface IFitnessCardService
    {
        Task<IEnumerable<AllFitnessCardViewModel>> AllFitnessCardAsync();
    }
}
