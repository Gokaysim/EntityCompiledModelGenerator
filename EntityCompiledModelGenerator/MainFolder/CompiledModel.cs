using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using test.IdentityRoleClaimClasses;
using test.IdentityUserClaimClasses;
using test.IdentityUserLoginClasses;
using test.IdentityUserRoleClasses;
using test.IdentityUserTokenClasses;
using test.AdminClasses;
using test.ClientClasses;
using test.ClientPhotoClasses;
using test.CityClasses;
using test.CountryClasses;
using test.CountryDetailClasses;
using test.CommentClasses;
using test.RateClasses;
using test.CompanyClasses;
using test.EarningClasses;
using test.PaymentClasses;
using test.PayTrPaymentClasses;
using test.PayTrTransferClasses;
using test.AppRoleClasses;
using test.AppUserClasses;
using test.MottoWorkerClasses;
using test.PartnerClasses;
using test.PartnerAccountClasses;
using test.PartnerAddressClasses;
using test.PartnerPhoneClasses;
using test.ReservationClasses;
using test.TourExtraReservationClasses;
using test.TourReservationClasses;
using test.PopularServiceClasses;
using test.ServiceClasses;
using test.SubcategoryTourMatchClasses;
using test.TourClasses;
using test.TourAddressClasses;
using test.TourCategoryClasses;
using test.TourCategoryDetailClasses;
using test.TourDetailClasses;
using test.TourExtraClasses;
using test.TourExtraDetailClasses;
using test.TourImageClasses;
using test.TourSubcategoryClasses;
using test.TourSubcategoryDetailClasses;


namespace test
{
    public class CompiledModel:IModel
    {
        private static CompiledModel _instance;
                
        public static CompiledModel GetInstance()
        {
            if(_instance==null)
            {
                _instance = new CompiledModel();
            }
            return _instance;
        }
        
        private IEnumerable<IAnnotation> _annotations; 
        public IAnnotation FindAnnotation(string name)
        {
            return GetAnnotations().FirstOrDefault(p => p.Name == name);
        }

        public static IEntityType FindEntityType( Type type)
        {
	        return null;
        }

        public IEnumerable<IAnnotation> GetAnnotations()
        {
            if (_annotations == null)
            {
                _annotations = new List<IAnnotation>();
            }

            return _annotations;
        }

        public object this[string name] => FindAnnotation(name);

        private IEnumerable<IEntityType> _entityTypes;
        public IEnumerable<IEntityType> GetEntityTypes()
        {
            if (_entityTypes == null)
            {
                _entityTypes = new List<IEntityType>
				{
					IdentityRoleClaimEntityType.GetInstance(),
					IdentityUserClaimEntityType.GetInstance(),
					IdentityUserLoginEntityType.GetInstance(),
					IdentityUserRoleEntityType.GetInstance(),
					IdentityUserTokenEntityType.GetInstance(),
					AdminEntityType.GetInstance(),
					ClientEntityType.GetInstance(),
					ClientPhotoEntityType.GetInstance(),
					CityEntityType.GetInstance(),
					CountryEntityType.GetInstance(),
					CountryDetailEntityType.GetInstance(),
					CommentEntityType.GetInstance(),
					RateEntityType.GetInstance(),
					CompanyEntityType.GetInstance(),
					EarningEntityType.GetInstance(),
					PaymentEntityType.GetInstance(),
					PayTrPaymentEntityType.GetInstance(),
					PayTrTransferEntityType.GetInstance(),
					AppRoleEntityType.GetInstance(),
					AppUserEntityType.GetInstance(),
					MottoWorkerEntityType.GetInstance(),
					PartnerEntityType.GetInstance(),
					PartnerAccountEntityType.GetInstance(),
					PartnerAddressEntityType.GetInstance(),
					PartnerPhoneEntityType.GetInstance(),
					ReservationEntityType.GetInstance(),
					TourExtraReservationEntityType.GetInstance(),
					TourReservationEntityType.GetInstance(),
					PopularServiceEntityType.GetInstance(),
					ServiceEntityType.GetInstance(),
					SubcategoryTourMatchEntityType.GetInstance(),
					TourEntityType.GetInstance(),
					TourAddressEntityType.GetInstance(),
					TourCategoryEntityType.GetInstance(),
					TourCategoryDetailEntityType.GetInstance(),
					TourDetailEntityType.GetInstance(),
					TourExtraEntityType.GetInstance(),
					TourExtraDetailEntityType.GetInstance(),
					TourImageEntityType.GetInstance(),
					TourSubcategoryEntityType.GetInstance(),
					TourSubcategoryDetailEntityType.GetInstance(),
				};
            }

            return _entityTypes;
        }

        public IEntityType FindEntityType(string name)
        {
            return GetEntityTypes().FirstOrDefault(p => p.Name == name);
        }

        public IEntityType FindEntityType(string name, string definingNavigationName, IEntityType definingEntityType)
        {
            return GetEntityTypes().FirstOrDefault(p => p.Name == name
                                                        && p.DefiningNavigationName == definingNavigationName
                                                        && p.DefiningEntityType == definingEntityType);
        }
    }
}