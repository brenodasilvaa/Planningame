using Planningame_Domain.Interfaces;
using Planningame_Insfrastructure;

namespace Inspira.Infrastructure
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly PlanningameDbContext context;

        public UnityOfWork(PlanningameDbContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
