using AbpPoc.Parts;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using AbpPoc.Ipbs;

namespace AbpPoc.Ipbs
{
    public class IpbsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IIpbRepository _ipbRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly PartsDataSeedContributor _partsDataSeedContributor;

        public IpbsDataSeedContributor(IIpbRepository ipbRepository, IUnitOfWorkManager unitOfWorkManager, PartsDataSeedContributor partsDataSeedContributor)
        {
            _ipbRepository = ipbRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _partsDataSeedContributor = partsDataSeedContributor;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _partsDataSeedContributor.SeedAsync(context);

            await _ipbRepository.InsertAsync(new Ipb
            (
                id: Guid.Parse("972fa525-d23b-4818-9924-621d597c8445"),
                ipbIndex: "794b03c2",
                figureName: "a8119d3f93ea466b8da9b3592da0936a0264e4dc8c2c47c8b1231dd40ad9947dd676336aa4a24716ab69d2dbf234a0156e6092f347c04def93dc324194fb5b392869386bc3ee40318f5ea561130657d095d52f3fe762482cb59c1f8ef7c5b629bcc6ee65555f4472836edd7a8a7a28d09d225ff2317648dab02c63d8f1ab7298",
                figureNumber: "a3625971623c4d969b96c610ae203613873063af01744b8da8ac63b5234d26f65ff62ac28ef34d698071af9b64b006b9894f472389b84d0397d4f81592fc83fba99f0900d40f47e6ae27d988a3ff346822fd62cf412f4589bf384f277d449e128d331f115f5a41e2b78c23caa32c671da869e909e3ce45508028018156be1571",
                toNumber: "4acd3f802b8e44f192e67824389b8e44",
                indentureLevel: "c2dc186e",
                sourceId: "2d61651d0060436ca65c8c1ac0010c4731328c4a5435429382c2076c3dd5a7d383a",
                relatedId: "83ecae3d26184e9cab8b6582a3c050bd2edaa40a95b",
                sourcePart: null,
                relatedPart: null
            ));

            await _ipbRepository.InsertAsync(new Ipb
            (
                id: Guid.Parse("d4be035a-63dd-4e33-ad73-5215311c83d5"),
                ipbIndex: "c3b71b78",
                figureName: "1a3e314b5fc1492d8e63efaf053b91ce9d7da1f54e4b4f5b80440965069916c9c6730641eb8747bab6fdf08604f5e919027a28c2eeed4bc4bcce90205d189875d9dcc3cf032946ce9a8837c5aa06c062430f55d8cac54e32b94b256ecd70c1e24fb7ac344410476ea6dbcf077320f6e855160f9583c74beab021f2c1aad2f011",
                figureNumber: "a180f68d9e94457396ecfeabcd724d1b30c84fa20bc140218b6ad84ad05ad474531f220269ff400ba6ad57cada3183f2db2a2b702f2e4e5bae7fcbb784c5785b0745cf292dab42c091253f0c7b998118fd1532c50c6841529a55a103cd10a4edc21913f93b8a47d499d9e1996f6b50925ad16abdc87245f6a6ca5950509e11ab",
                toNumber: "03238aa639ba4cd3a2e2fc85063bdfa3",
                indentureLevel: "faec9653",
                sourceId: "e628a86bb7444270918a3d914fd9b104199ea72b36394e39aefefe0b49c8fb23c5d4cf",
                relatedId: "c3d27ce5e3ff4",
                sourcePart: null,
                relatedPart: null
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}