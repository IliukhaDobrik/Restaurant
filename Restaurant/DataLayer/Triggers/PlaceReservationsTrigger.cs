using DataLayer.Repositories.Interfaces;
using Entities;
using EntityFrameworkCore.Triggered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Triggers
{
    public class PlaceReservationsTrigger : IAfterSaveTrigger<User>
    {
        private readonly IPlaceRepository _placeRepository;
        public PlaceReservationsTrigger(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task AfterSave(ITriggerContext<User> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Modified && context.Entity.PlaceId.HasValue)
            {
                var place = await _placeRepository.GetById(context.Entity.PlaceId.Value);
                place.IsFree = false;

                _placeRepository.Update(place);
                await _placeRepository.Save();
            }
        }
    }
}
