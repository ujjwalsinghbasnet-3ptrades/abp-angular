using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AbpPoc.PartTests;

namespace AbpPoc.PartTests
{
    public class PartTestsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IPartTestRepository _partTestRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public PartTestsDataSeedContributor(IPartTestRepository partTestRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _partTestRepository = partTestRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _partTestRepository.InsertAsync(new PartTest
            (
                id: Guid.Parse("cd2d84d3-6d16-441c-9fdd-f41451f29fd2"),
                partNumber: "b3841ad2865c4996892e8943ed0fdbf2f5c7e36df433476a90b40034116f01173e38",
                name: "868bfbec272d43529f",
                cageCode: "0eaacca22db643c38a1c7765610df412f1211096b",
                distributionStatement: "dbdf67c54b8d45cdacb261b3ba930571c7d2be7fea324fb09721",
                toNumber: "c4b1089a68fc46d982798ad75d1ddd739269ab72bc9f4dcc8a093cc8373c70f8e1da0a5efb22423a8281ebf5ade3e67e",
                smr: "44799b9cfa5744159045081d66249640c338107d864149078208e890b0a28937440889cba2ca4d5",
                niin: "5b13508db0f2441aac4e4dc37d58",
                fsc: "e95e890790644a349f34b7c7",
                wuc: "3e57514b5d4d407ebbf22a17faf5a45cb71ed34b8c4e4c",
                uoc: "79c504db46a648a0a1345c7d52cbc33437356bc815f54984a9c439ab59cefab27d",
                uniqueId: "458ad3acec9c45d09b12a2e3b4b20da8ef3e47a5c2bb40",
                nsn: "6701aa3573b24945b4c118610633a971249",
                imageUrl: "c979a0a6961d4486a02ee8fe43887c83b16fc0c87c6e45318946c290d630170676b282f390324144b"
            ));

            await _partTestRepository.InsertAsync(new PartTest
            (
                id: Guid.Parse("3901aef8-f48d-4395-a578-2d9971174315"),
                partNumber: "714db68247824c48a19115fdee73ccfd66e6f1676b4141dca094845ef097b7cb86122f467c9",
                name: "a16938291032470abe936f9c5507a45265f7fa028dfd491fafcb1988168728db3a2336ec24c7460db2",
                cageCode: "fbb33115eaf24b60b7fe40c4fefeffcf4",
                distributionStatement: "29b191fff2ea43ed85e5a9b4da27c0e7b707c0207bd740538434e7040fbfee66",
                toNumber: "3f86895e997543bbb37e57b08075bfa6a32a5646efaf4fd7b6419055e2782323db69c5f9ecfc4e59b149a4e0442c3df46",
                smr: "a7fd2102d",
                niin: "47636c29966f4e55b6c255acf603f075624437bfcba94a5b968c7d48815fd9ed1ae4dbab70ac45609a99b3",
                fsc: "3c90dc96deb042858fb873710f7c47bde0d6249a3",
                wuc: "f9e1603128c641cb8235c46c3ec588512105524a61914de49a8196d",
                uoc: "d05f96d1095e4602b8ec923514d4df2a6",
                uniqueId: "8c1556377e9c402989b722a5aced26f9e9e7191d7b7948ecb05f64fa87",
                nsn: "caf1040f4bdf40a09bf0b8e5b1",
                imageUrl: "4b26b9e43c1f40388ec029519156d458ec7d7d5fa2f94e529f2d9c91b068567"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}