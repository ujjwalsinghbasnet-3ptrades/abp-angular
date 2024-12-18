using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AbpPoc.Parts;

namespace AbpPoc.Parts
{
    public class PartsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPartRepository _partRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PartsDataSeedContributor(IPartRepository partRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _partRepository = partRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _partRepository.InsertAsync(new Part
            (
                id: Guid.Parse("218e0563-5ee5-407f-a06c-591425acceb9"),
                name: "7a2",
                description: "096580d24c5840bf88d22b5e7fc242a11f5898e3e24f471b",
                partNumber: "03959147e0034a3",
                cageCode: "fbf01c49509742cc872428deca1893a2",
                toNumber: "f4df58e480874b0b9167bd1c",
                distributionStatement: "4a1d9acdbdd",
                smr: "8f2c7e59ba5a4ffb975921df08a013dd",
                niin: "a8fcb87a489a4da0ba8824cfdf24072b1dfdf7256e8346aa8e08b62de28",
                fsc: "c7600c5198b649f2a46816f44553d5494c3ff067",
                wuc: "40fb71a910f747108d90261c02ad3898212b02378e664b3ab2d53",
                uoc: "e8b72cdedae24034902ec1773ce7e150f6f642f1222848b29c5ca2fd2f41786da7c33e1925374e36bbf5daea",
                uniqueId: "f28529d77fd343b6bcadd",
                nsn: "1f53d2300ac84e6e876f02e31ca2d5763098c9b299c04e7f8",
                imageUrl: "d2ac04a43fc64d4bba52c00d110086e89d3f5dba42044c0d"
            ));

            await _partRepository.InsertAsync(new Part
            (
                id: Guid.Parse("65cd60da-c218-4d7a-8f3f-4ae736ac0726"),
                name: "ca7",
                description: "b95f4e07f9e8495dad8a37c29509d4d46ab",
                partNumber: "29bc3e2b638c41f39d6a0c3117ddfdcf941ae69cdeb1407785fc8a",
                cageCode: "59c98332282b404585db4b71495b6fa9b5d600",
                toNumber: "ef50304180c744e",
                distributionStatement: "27bd67c76f254971815d48fafa7ed01828b9",
                smr: "b117c13949dc498ba196c426f269b92a6",
                niin: "2f502f0a9a5b472ab02c73e2ce1f3150eea4929b90014ad0ba95cfca047095bed1450a453435457b9d15c2c2b7fc3d",
                fsc: "7e20831b97874a5e8e96",
                wuc: "fd006d529e3f4688a0561a4a7c9457c6d1a93dc17c8b49268a5047018b7e67518c74925c0210452",
                uoc: "bbe6c2f7ca9446c38c9b0e070020cddec3048590a3f446648e36083bc6a10c271",
                uniqueId: "80a9077a225f44f0b3a19aa585fddc73debc98a46d8d4aada0a40163676e1a206e0c564a",
                nsn: "dbdd67f31d0d4704806bc81afb58a2f1b784d",
                imageUrl: "8c4ed51d0b78464b9616919938524126bd46cb363"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}