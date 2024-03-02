using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HardwareStore.App.Migrations
{
    public partial class removingUsernameFieldFromProductReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ProductReviews");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "00f7b9f8-49fc-45a3-a8fa-43a0c96b62dd",
                column: "FilePath",
                value: "/Images/00f7b9f8-49fc-45a3-a8fa-43a0c96b62dd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "03c91e40-c117-460a-8454-60ca9e771c38",
                column: "FilePath",
                value: "/Images/03c91e40-c117-460a-8454-60ca9e771c38.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "04d4d665-98b4-40ed-83de-9b7cf3311444",
                column: "FilePath",
                value: "/Images/04d4d665-98b4-40ed-83de-9b7cf3311444.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "06d3b2eb-ac3a-47a7-82a5-e363d20096f1",
                column: "FilePath",
                value: "/Images/06d3b2eb-ac3a-47a7-82a5-e363d20096f1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "09230f47-7964-4e73-b4ce-4fd9d613f0a5",
                column: "FilePath",
                value: "/Images/09230f47-7964-4e73-b4ce-4fd9d613f0a5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "09c41293-55d6-4bb2-ab31-0f127ee7318c",
                column: "FilePath",
                value: "/Images/09c41293-55d6-4bb2-ab31-0f127ee7318c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "0be57707-e0c2-4177-af7a-591415d0c00a",
                column: "FilePath",
                value: "/Images/0be57707-e0c2-4177-af7a-591415d0c00a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "0bf93fd0-19e8-4486-a08c-bfe097bb1c22",
                column: "FilePath",
                value: "/Images/0bf93fd0-19e8-4486-a08c-bfe097bb1c22.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "0e6086b0-4555-4f77-8bce-2cc581472780",
                column: "FilePath",
                value: "/Images/0e6086b0-4555-4f77-8bce-2cc581472780.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "11f02df0-ed66-410c-a126-f1147ae4a54c",
                column: "FilePath",
                value: "/Images/11f02df0-ed66-410c-a126-f1147ae4a54c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "11f11e54-3c3a-4257-bd90-9bf8de1393b2",
                column: "FilePath",
                value: "/Images/11f11e54-3c3a-4257-bd90-9bf8de1393b2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "12fe677c-7697-48f6-bf52-64c3df981a26",
                column: "FilePath",
                value: "/Images/12fe677c-7697-48f6-bf52-64c3df981a26.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "17a14db7-ad18-4a06-a149-4a6872d77972",
                column: "FilePath",
                value: "/Images/17a14db7-ad18-4a06-a149-4a6872d77972.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "202af0b0-41f3-4744-a862-483fd01a92b2",
                column: "FilePath",
                value: "/Images/202af0b0-41f3-4744-a862-483fd01a92b2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "20ae62e9-42aa-4969-8cf6-ad878e2fb573",
                column: "FilePath",
                value: "/Images/20ae62e9-42aa-4969-8cf6-ad878e2fb573.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "21b8572c-f178-4ba9-9308-475b9a3ac2b3",
                column: "FilePath",
                value: "/Images/21b8572c-f178-4ba9-9308-475b9a3ac2b3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "24f043ca-72a5-4bb6-8580-2e1907613542",
                column: "FilePath",
                value: "/Images/24f043ca-72a5-4bb6-8580-2e1907613542.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "252a502e-94fe-42ef-b287-9883a9c631ae",
                column: "FilePath",
                value: "/Images/252a502e-94fe-42ef-b287-9883a9c631ae.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "2553abe7-63c8-4da5-b338-a899d0a80e8b",
                column: "FilePath",
                value: "/Images/2553abe7-63c8-4da5-b338-a899d0a80e8b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "2593176e-20bf-4392-9b27-1abfbcb1d1c2",
                column: "FilePath",
                value: "/Images/2593176e-20bf-4392-9b27-1abfbcb1d1c2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "274c6543-3980-4c11-8664-2f618907e7e8",
                column: "FilePath",
                value: "/Images/274c6543-3980-4c11-8664-2f618907e7e8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "28e8257b-25d3-4114-b523-c0f778129fe1",
                column: "FilePath",
                value: "/Images/28e8257b-25d3-4114-b523-c0f778129fe1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "28e968e1-e5a1-4532-a11a-775cfc02f114",
                column: "FilePath",
                value: "/Images/28e968e1-e5a1-4532-a11a-775cfc02f114.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "2b9e3dac-3cc8-43e3-bfb8-b63118fccffe",
                column: "FilePath",
                value: "/Images/2b9e3dac-3cc8-43e3-bfb8-b63118fccffe.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "319d5f95-24c2-434a-82b0-3462b0ddf4b3",
                column: "FilePath",
                value: "/Images/319d5f95-24c2-434a-82b0-3462b0ddf4b3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "32792424-48fe-4e32-9fe7-241afc3c215d",
                column: "FilePath",
                value: "/Images/32792424-48fe-4e32-9fe7-241afc3c215d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "33848993-28f5-468f-8a2d-1d2d2cc160c2",
                column: "FilePath",
                value: "/Images/33848993-28f5-468f-8a2d-1d2d2cc160c2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "3667240a-f95f-4da5-8895-b7ee370e5c7c",
                column: "FilePath",
                value: "/Images/3667240a-f95f-4da5-8895-b7ee370e5c7c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "3850f95a-562f-4bb8-af27-f937ef1cd13a",
                column: "FilePath",
                value: "/Images/3850f95a-562f-4bb8-af27-f937ef1cd13a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "3b88db86-67e1-4aac-9e39-0d765a554949",
                column: "FilePath",
                value: "/Images/3b88db86-67e1-4aac-9e39-0d765a554949.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "41f8ee04-f97f-41d8-8cba-18ad9dd01217",
                column: "FilePath",
                value: "/Images/41f8ee04-f97f-41d8-8cba-18ad9dd01217.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "42d1ebb0-6b86-4b09-ad4f-4f34c189b01c",
                column: "FilePath",
                value: "/Images/42d1ebb0-6b86-4b09-ad4f-4f34c189b01c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "42fb9716-1e61-4e4f-ae83-e8043b6c9ba0",
                column: "FilePath",
                value: "/Images/42fb9716-1e61-4e4f-ae83-e8043b6c9ba0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4369891f-6ffc-4227-b3f2-4ec660ea74b9",
                column: "FilePath",
                value: "/Images/4369891f-6ffc-4227-b3f2-4ec660ea74b9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4588eab1-c87c-4661-9ddc-8d9c9de8c4b8",
                column: "FilePath",
                value: "/Images/4588eab1-c87c-4661-9ddc-8d9c9de8c4b8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "490f8038-9bad-4180-a0d2-39e9e9f6292f",
                column: "FilePath",
                value: "/Images/490f8038-9bad-4180-a0d2-39e9e9f6292f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "49eb0ef2-158b-4d65-a292-1c133a777621",
                column: "FilePath",
                value: "/Images/49eb0ef2-158b-4d65-a292-1c133a777621.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4a338c8d-2537-4766-8c67-f4446ff478f2",
                column: "FilePath",
                value: "/Images/4a338c8d-2537-4766-8c67-f4446ff478f2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4f9f15d2-126e-4ac9-9cea-1fe8b9e86f97",
                column: "FilePath",
                value: "/Images/4f9f15d2-126e-4ac9-9cea-1fe8b9e86f97.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "503a5bdb-be29-4da5-9440-5022c33f36ac",
                column: "FilePath",
                value: "/Images/503a5bdb-be29-4da5-9440-5022c33f36ac.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "50ec92b2-38ee-4b77-a52c-7cbab6b3f7ac",
                column: "FilePath",
                value: "/Images/50ec92b2-38ee-4b77-a52c-7cbab6b3f7ac.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "51de09d5-30ae-45d1-ba22-0000251ca087",
                column: "FilePath",
                value: "/Images/51de09d5-30ae-45d1-ba22-0000251ca087.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5267ec91-ad23-4a73-9fde-20271907e089",
                column: "FilePath",
                value: "/Images/5267ec91-ad23-4a73-9fde-20271907e089.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5366937c-e4fd-4147-b88b-d42cdc5a214a",
                column: "FilePath",
                value: "/Images/5366937c-e4fd-4147-b88b-d42cdc5a214a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5474f429-2dc7-40ec-9af1-7a81c24db43f",
                column: "FilePath",
                value: "/Images/5474f429-2dc7-40ec-9af1-7a81c24db43f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "54bbd9b8-16f4-41a5-895a-2395549fb8ca",
                column: "FilePath",
                value: "/Images/54bbd9b8-16f4-41a5-895a-2395549fb8ca.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "574ed2e4-cdec-4133-a588-5241c263f6b8",
                column: "FilePath",
                value: "/Images/574ed2e4-cdec-4133-a588-5241c263f6b8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "589ede3e-390d-4395-9bf3-799bfaf06701",
                column: "FilePath",
                value: "/Images/589ede3e-390d-4395-9bf3-799bfaf06701.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5c73024d-d613-4fae-9873-0e88ff7289c8",
                column: "FilePath",
                value: "/Images/5c73024d-d613-4fae-9873-0e88ff7289c8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5d956bf3-d052-44bf-ae8f-29e945da2bb9",
                column: "FilePath",
                value: "/Images/5d956bf3-d052-44bf-ae8f-29e945da2bb9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5f206e19-dea7-4c40-91e7-852458e61831",
                column: "FilePath",
                value: "/Images/5f206e19-dea7-4c40-91e7-852458e61831.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "616f99ab-d19f-43cb-9743-f62376b7cd10",
                column: "FilePath",
                value: "/Images/616f99ab-d19f-43cb-9743-f62376b7cd10.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "6625b408-607b-48d2-91d8-356ba3e684dd",
                column: "FilePath",
                value: "/Images/6625b408-607b-48d2-91d8-356ba3e684dd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "66986a8c-76fb-4626-a2b7-93b4d4aae61f",
                column: "FilePath",
                value: "/Images/66986a8c-76fb-4626-a2b7-93b4d4aae61f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "66d9eb05-c031-4e76-bb69-0c650657ff94",
                column: "FilePath",
                value: "/Images/66d9eb05-c031-4e76-bb69-0c650657ff94.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "71db4dae-fa71-4311-84b5-ea7b29fcf5fa",
                column: "FilePath",
                value: "/Images/71db4dae-fa71-4311-84b5-ea7b29fcf5fa.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "729cfb1b-62fd-4a7f-a11c-b073bd0d8969",
                column: "FilePath",
                value: "/Images/729cfb1b-62fd-4a7f-a11c-b073bd0d8969.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "7580baab-5081-45a2-b227-787ab2263775",
                column: "FilePath",
                value: "/Images/7580baab-5081-45a2-b227-787ab2263775.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "76f054da-5ffc-4fe3-aa6b-8d6743cf83a9",
                column: "FilePath",
                value: "/Images/76f054da-5ffc-4fe3-aa6b-8d6743cf83a9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "77eaf7c6-e81d-4338-be23-a6d84ceb04ca",
                column: "FilePath",
                value: "/Images/77eaf7c6-e81d-4338-be23-a6d84ceb04ca.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "7a8ba6fe-03d7-485e-b3af-8cdeec70d067",
                column: "FilePath",
                value: "/Images/7a8ba6fe-03d7-485e-b3af-8cdeec70d067.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "7d963661-04f6-43ae-a1e8-f314b597627d",
                column: "FilePath",
                value: "/Images/7d963661-04f6-43ae-a1e8-f314b597627d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "824fc1f4-6e52-4776-9ca5-e42e54e68e69",
                column: "FilePath",
                value: "/Images/824fc1f4-6e52-4776-9ca5-e42e54e68e69.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "83f98923-0661-44ee-b1aa-be4411619690",
                column: "FilePath",
                value: "/Images/83f98923-0661-44ee-b1aa-be4411619690.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "852824a2-c4bd-4582-8f74-9e02667cd57a",
                column: "FilePath",
                value: "/Images/852824a2-c4bd-4582-8f74-9e02667cd57a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "85a78cf1-d5af-4363-a2a2-13837485f50f",
                column: "FilePath",
                value: "/Images/85a78cf1-d5af-4363-a2a2-13837485f50f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "868302ff-1931-4b03-9afe-9c3c321dcb3b",
                column: "FilePath",
                value: "/Images/868302ff-1931-4b03-9afe-9c3c321dcb3b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8982521c-bcd4-4ee4-a712-6085d687e588",
                column: "FilePath",
                value: "/Images/8982521c-bcd4-4ee4-a712-6085d687e588.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8ca5997f-53fe-4bf4-8af9-e95994dbb61d",
                column: "FilePath",
                value: "/Images/8ca5997f-53fe-4bf4-8af9-e95994dbb61d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8f833fa0-8648-4f0c-bd2f-914fa872ff6a",
                column: "FilePath",
                value: "/Images/8f833fa0-8648-4f0c-bd2f-914fa872ff6a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8fd47fe2-a487-4fce-9c1b-427de0af5d9e",
                column: "FilePath",
                value: "/Images/8fd47fe2-a487-4fce-9c1b-427de0af5d9e.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "91cd8cd7-0b1f-4ad7-a9e2-efe029133c78",
                column: "FilePath",
                value: "/Images/91cd8cd7-0b1f-4ad7-a9e2-efe029133c78.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "926a0cc9-f77f-4d38-a4ed-80954038182b",
                column: "FilePath",
                value: "/Images/926a0cc9-f77f-4d38-a4ed-80954038182b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "92dd4206-5009-4274-9340-41d101a666ef",
                column: "FilePath",
                value: "/Images/92dd4206-5009-4274-9340-41d101a666ef.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "94be617b-2886-4796-a816-e70d8254db5c",
                column: "FilePath",
                value: "/Images/94be617b-2886-4796-a816-e70d8254db5c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9650da52-cfd0-4da3-a484-8b5d47b896a0",
                column: "FilePath",
                value: "/Images/9650da52-cfd0-4da3-a484-8b5d47b896a0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "984fdc6b-11f3-4b24-ab69-6f4eb853d722",
                column: "FilePath",
                value: "/Images/984fdc6b-11f3-4b24-ab69-6f4eb853d722.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "988610ab-3fdb-46b8-883a-511e709c51f9",
                column: "FilePath",
                value: "/Images/988610ab-3fdb-46b8-883a-511e709c51f9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "997a8f8f-9e44-4925-b898-ace5cd35bfcd",
                column: "FilePath",
                value: "/Images/997a8f8f-9e44-4925-b898-ace5cd35bfcd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9a4f1cef-e773-4b24-9f8c-c4359001b1dd",
                column: "FilePath",
                value: "/Images/9a4f1cef-e773-4b24-9f8c-c4359001b1dd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9aede4aa-7c74-44d1-a70b-201b79442096",
                column: "FilePath",
                value: "/Images/9aede4aa-7c74-44d1-a70b-201b79442096.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a10bdd3e-a845-4cb4-9079-0ec9729cd2ff",
                column: "FilePath",
                value: "/Images/a10bdd3e-a845-4cb4-9079-0ec9729cd2ff.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a1554699-e1bf-44d6-83d1-c9196b545703",
                column: "FilePath",
                value: "/Images/a1554699-e1bf-44d6-83d1-c9196b545703.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a2b37b1f-827f-4ffd-ad2a-6a4a5ecdd938",
                column: "FilePath",
                value: "/Images/a2b37b1f-827f-4ffd-ad2a-6a4a5ecdd938.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a326c01d-f7b2-4f67-9a5d-4944f8960f10",
                column: "FilePath",
                value: "/Images/a326c01d-f7b2-4f67-9a5d-4944f8960f10.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a5afb091-9e09-4a84-9f58-e14d3685e1e7",
                column: "FilePath",
                value: "/Images/a5afb091-9e09-4a84-9f58-e14d3685e1e7.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a6089e18-0213-4564-a0a1-c3923cc9466f",
                column: "FilePath",
                value: "/Images/a6089e18-0213-4564-a0a1-c3923cc9466f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a6cb50fc-d720-438f-b2fb-b2abf73ad1d0",
                column: "FilePath",
                value: "/Images/a6cb50fc-d720-438f-b2fb-b2abf73ad1d0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a8b7d89b-08eb-485f-9059-03fe91ee36d2",
                column: "FilePath",
                value: "/Images/a8b7d89b-08eb-485f-9059-03fe91ee36d2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "aa8c05b7-c942-4397-8a17-029c0d8dc875",
                column: "FilePath",
                value: "/Images/aa8c05b7-c942-4397-8a17-029c0d8dc875.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "aba175f1-63c2-4725-ae4b-740eecac6bf0",
                column: "FilePath",
                value: "/Images/aba175f1-63c2-4725-ae4b-740eecac6bf0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "abc2b28b-f750-45c4-9ebc-fd8d427a397a",
                column: "FilePath",
                value: "/Images/abc2b28b-f750-45c4-9ebc-fd8d427a397a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ac9c897f-0834-4041-b87b-0f3918f6df24",
                column: "FilePath",
                value: "/Images/ac9c897f-0834-4041-b87b-0f3918f6df24.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "af776ffc-d3ce-4313-b19d-dcb2a0a09cd4",
                column: "FilePath",
                value: "/Images/af776ffc-d3ce-4313-b19d-dcb2a0a09cd4.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b17cdfaf-7c31-4b18-adc9-0dec44672b09",
                column: "FilePath",
                value: "/Images/b17cdfaf-7c31-4b18-adc9-0dec44672b09.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b2eb45be-70f3-498e-91d5-e43f7861b47b",
                column: "FilePath",
                value: "/Images/b2eb45be-70f3-498e-91d5-e43f7861b47b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b4f70f16-4962-4adb-aa21-cbaae0e369bb",
                column: "FilePath",
                value: "/Images/b4f70f16-4962-4adb-aa21-cbaae0e369bb.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b5541707-2e00-45fc-9221-3f940ee50255",
                column: "FilePath",
                value: "/Images/b5541707-2e00-45fc-9221-3f940ee50255.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b69dab00-2857-4555-8d7b-7ae6db195795",
                column: "FilePath",
                value: "/Images/b69dab00-2857-4555-8d7b-7ae6db195795.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "bb1cefec-0b96-494e-915c-430b17063192",
                column: "FilePath",
                value: "/Images/bb1cefec-0b96-494e-915c-430b17063192.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "bd8bb8e7-1221-466e-8be8-1faaa623f3b4",
                column: "FilePath",
                value: "/Images/bd8bb8e7-1221-466e-8be8-1faaa623f3b4.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "be653ffe-93b8-4eeb-a9d3-7c7e8c27ca95",
                column: "FilePath",
                value: "/Images/be653ffe-93b8-4eeb-a9d3-7c7e8c27ca95.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "c649c783-fd90-40f1-b15e-1703623ddc8a",
                column: "FilePath",
                value: "/Images/c649c783-fd90-40f1-b15e-1703623ddc8a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cc4db4c9-b014-4fa4-891a-85051ad2a631",
                column: "FilePath",
                value: "/Images/cc4db4c9-b014-4fa4-891a-85051ad2a631.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cc98fedc-1307-4f2c-a830-c7cb312c9a07",
                column: "FilePath",
                value: "/Images/cc98fedc-1307-4f2c-a830-c7cb312c9a07.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cd1621e2-52d4-4190-9b14-70568d0ca2ed",
                column: "FilePath",
                value: "/Images/cd1621e2-52d4-4190-9b14-70568d0ca2ed.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cf221477-6c55-4318-8674-ee8a8f02f370",
                column: "FilePath",
                value: "/Images/cf221477-6c55-4318-8674-ee8a8f02f370.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cfcf1476-2863-4fe6-a892-8ffb8975b166",
                column: "FilePath",
                value: "/Images/cfcf1476-2863-4fe6-a892-8ffb8975b166.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cfe3ca17-7d35-4897-95a1-22fae8071309",
                column: "FilePath",
                value: "/Images/cfe3ca17-7d35-4897-95a1-22fae8071309.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d239df37-50c8-4e9b-a80d-04a1e6a8670a",
                column: "FilePath",
                value: "/Images/d239df37-50c8-4e9b-a80d-04a1e6a8670a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d353dbeb-9820-41b0-8e0b-8f3bf1fca1f5",
                column: "FilePath",
                value: "/Images/d353dbeb-9820-41b0-8e0b-8f3bf1fca1f5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d3617f44-7666-4563-82c0-d54aa838a954",
                column: "FilePath",
                value: "/Images/d3617f44-7666-4563-82c0-d54aa838a954.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d41da59e-ee18-44d2-8304-87a056c76767",
                column: "FilePath",
                value: "/Images/d41da59e-ee18-44d2-8304-87a056c76767.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d42d3600-ac00-4976-bb49-681f9d7c4e27",
                column: "FilePath",
                value: "/Images/d42d3600-ac00-4976-bb49-681f9d7c4e27.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d4ed8af0-c378-490c-bab2-09a95686808a",
                column: "FilePath",
                value: "/Images/d4ed8af0-c378-490c-bab2-09a95686808a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d4fda4f4-b48f-4da5-a6c9-693a3e3ef73b",
                column: "FilePath",
                value: "/Images/d4fda4f4-b48f-4da5-a6c9-693a3e3ef73b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d767d6bb-e3ab-4fa4-9398-9003de15cc00",
                column: "FilePath",
                value: "/Images/d767d6bb-e3ab-4fa4-9398-9003de15cc00.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "da97a2e9-d13e-4c08-bc7b-883c8d492f86",
                column: "FilePath",
                value: "/Images/da97a2e9-d13e-4c08-bc7b-883c8d492f86.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "de272047-1790-4f5f-bc74-a79ffb720335",
                column: "FilePath",
                value: "/Images/de272047-1790-4f5f-bc74-a79ffb720335.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "e0884d7b-45f0-4484-b72f-4ca35db6936f",
                column: "FilePath",
                value: "/Images/e0884d7b-45f0-4484-b72f-4ca35db6936f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "e0b29485-265a-4f85-a3db-1a65df513ae8",
                column: "FilePath",
                value: "/Images/e0b29485-265a-4f85-a3db-1a65df513ae8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "eb201225-6593-409b-955b-58603556f34b",
                column: "FilePath",
                value: "/Images/eb201225-6593-409b-955b-58603556f34b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "eb5bad8b-889a-4ebd-9966-145e4f787368",
                column: "FilePath",
                value: "/Images/eb5bad8b-889a-4ebd-9966-145e4f787368.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ec07baac-38f2-4d85-b278-7e1c2ed6ece5",
                column: "FilePath",
                value: "/Images/ec07baac-38f2-4d85-b278-7e1c2ed6ece5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ec2ac398-5973-4594-a155-e53d3f6b1b1d",
                column: "FilePath",
                value: "/Images/ec2ac398-5973-4594-a155-e53d3f6b1b1d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ed1a380d-d279-427e-89a0-91e9fb56167d",
                column: "FilePath",
                value: "/Images/ed1a380d-d279-427e-89a0-91e9fb56167d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "edc756ff-7dec-42c0-8fd6-d6baeeff938f",
                column: "FilePath",
                value: "/Images/edc756ff-7dec-42c0-8fd6-d6baeeff938f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f0eff95f-91ff-4f96-b703-2576a8ab50b5",
                column: "FilePath",
                value: "/Images/f0eff95f-91ff-4f96-b703-2576a8ab50b5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f19aaa80-4cdd-443a-a542-8eeb1320998c",
                column: "FilePath",
                value: "/Images/f19aaa80-4cdd-443a-a542-8eeb1320998c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f4c93663-203a-45bf-ae7c-e76ab78dd290",
                column: "FilePath",
                value: "/Images/f4c93663-203a-45bf-ae7c-e76ab78dd290.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f68fdafc-f5db-4ab7-94ae-81a09e4f817c",
                column: "FilePath",
                value: "/Images/f68fdafc-f5db-4ab7-94ae-81a09e4f817c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f741bca7-e0b3-414d-bdcd-40c0c9ff3cdd",
                column: "FilePath",
                value: "/Images/f741bca7-e0b3-414d-bdcd-40c0c9ff3cdd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f981971f-a887-43ca-b3e2-4f39f613483d",
                column: "FilePath",
                value: "/Images/f981971f-a887-43ca-b3e2-4f39f613483d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f98b5387-e029-4ab9-8366-f764b5313e4c",
                column: "FilePath",
                value: "/Images/f98b5387-e029-4ab9-8366-f764b5313e4c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fad4f25c-7bb3-4a17-ba18-c9b2969e8852",
                column: "FilePath",
                value: "/Images/fad4f25c-7bb3-4a17-ba18-c9b2969e8852.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fcf45d3e-bd42-4e4f-90ce-d37b26f58995",
                column: "FilePath",
                value: "/Images/fcf45d3e-bd42-4e4f-90ce-d37b26f58995.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fd700b5d-ae2f-4dae-91ae-46d8f3bf3be2",
                column: "FilePath",
                value: "/Images/fd700b5d-ae2f-4dae-91ae-46d8f3bf3be2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fe1a4e59-6541-4d42-ad4a-90094c4b8c97",
                column: "FilePath",
                value: "/Images/fe1a4e59-6541-4d42-ad4a-90094c4b8c97.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ProductReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "00f7b9f8-49fc-45a3-a8fa-43a0c96b62dd",
                column: "FilePath",
                value: "Images/00f7b9f8-49fc-45a3-a8fa-43a0c96b62dd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "03c91e40-c117-460a-8454-60ca9e771c38",
                column: "FilePath",
                value: "Images/03c91e40-c117-460a-8454-60ca9e771c38.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "04d4d665-98b4-40ed-83de-9b7cf3311444",
                column: "FilePath",
                value: "Images/04d4d665-98b4-40ed-83de-9b7cf3311444.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "06d3b2eb-ac3a-47a7-82a5-e363d20096f1",
                column: "FilePath",
                value: "Images/06d3b2eb-ac3a-47a7-82a5-e363d20096f1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "09230f47-7964-4e73-b4ce-4fd9d613f0a5",
                column: "FilePath",
                value: "Images/09230f47-7964-4e73-b4ce-4fd9d613f0a5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "09c41293-55d6-4bb2-ab31-0f127ee7318c",
                column: "FilePath",
                value: "Images/09c41293-55d6-4bb2-ab31-0f127ee7318c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "0be57707-e0c2-4177-af7a-591415d0c00a",
                column: "FilePath",
                value: "Images/0be57707-e0c2-4177-af7a-591415d0c00a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "0bf93fd0-19e8-4486-a08c-bfe097bb1c22",
                column: "FilePath",
                value: "Images/0bf93fd0-19e8-4486-a08c-bfe097bb1c22.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "0e6086b0-4555-4f77-8bce-2cc581472780",
                column: "FilePath",
                value: "Images/0e6086b0-4555-4f77-8bce-2cc581472780.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "11f02df0-ed66-410c-a126-f1147ae4a54c",
                column: "FilePath",
                value: "Images/11f02df0-ed66-410c-a126-f1147ae4a54c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "11f11e54-3c3a-4257-bd90-9bf8de1393b2",
                column: "FilePath",
                value: "Images/11f11e54-3c3a-4257-bd90-9bf8de1393b2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "12fe677c-7697-48f6-bf52-64c3df981a26",
                column: "FilePath",
                value: "Images/12fe677c-7697-48f6-bf52-64c3df981a26.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "17a14db7-ad18-4a06-a149-4a6872d77972",
                column: "FilePath",
                value: "Images/17a14db7-ad18-4a06-a149-4a6872d77972.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "202af0b0-41f3-4744-a862-483fd01a92b2",
                column: "FilePath",
                value: "Images/202af0b0-41f3-4744-a862-483fd01a92b2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "20ae62e9-42aa-4969-8cf6-ad878e2fb573",
                column: "FilePath",
                value: "Images/20ae62e9-42aa-4969-8cf6-ad878e2fb573.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "21b8572c-f178-4ba9-9308-475b9a3ac2b3",
                column: "FilePath",
                value: "Images/21b8572c-f178-4ba9-9308-475b9a3ac2b3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "24f043ca-72a5-4bb6-8580-2e1907613542",
                column: "FilePath",
                value: "Images/24f043ca-72a5-4bb6-8580-2e1907613542.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "252a502e-94fe-42ef-b287-9883a9c631ae",
                column: "FilePath",
                value: "Images/252a502e-94fe-42ef-b287-9883a9c631ae.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "2553abe7-63c8-4da5-b338-a899d0a80e8b",
                column: "FilePath",
                value: "Images/2553abe7-63c8-4da5-b338-a899d0a80e8b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "2593176e-20bf-4392-9b27-1abfbcb1d1c2",
                column: "FilePath",
                value: "Images/2593176e-20bf-4392-9b27-1abfbcb1d1c2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "274c6543-3980-4c11-8664-2f618907e7e8",
                column: "FilePath",
                value: "Images/274c6543-3980-4c11-8664-2f618907e7e8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "28e8257b-25d3-4114-b523-c0f778129fe1",
                column: "FilePath",
                value: "Images/28e8257b-25d3-4114-b523-c0f778129fe1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "28e968e1-e5a1-4532-a11a-775cfc02f114",
                column: "FilePath",
                value: "Images/28e968e1-e5a1-4532-a11a-775cfc02f114.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "2b9e3dac-3cc8-43e3-bfb8-b63118fccffe",
                column: "FilePath",
                value: "Images/2b9e3dac-3cc8-43e3-bfb8-b63118fccffe.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "319d5f95-24c2-434a-82b0-3462b0ddf4b3",
                column: "FilePath",
                value: "Images/319d5f95-24c2-434a-82b0-3462b0ddf4b3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "32792424-48fe-4e32-9fe7-241afc3c215d",
                column: "FilePath",
                value: "Images/32792424-48fe-4e32-9fe7-241afc3c215d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "33848993-28f5-468f-8a2d-1d2d2cc160c2",
                column: "FilePath",
                value: "Images/33848993-28f5-468f-8a2d-1d2d2cc160c2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "3667240a-f95f-4da5-8895-b7ee370e5c7c",
                column: "FilePath",
                value: "Images/3667240a-f95f-4da5-8895-b7ee370e5c7c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "3850f95a-562f-4bb8-af27-f937ef1cd13a",
                column: "FilePath",
                value: "Images/3850f95a-562f-4bb8-af27-f937ef1cd13a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "3b88db86-67e1-4aac-9e39-0d765a554949",
                column: "FilePath",
                value: "Images/3b88db86-67e1-4aac-9e39-0d765a554949.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "41f8ee04-f97f-41d8-8cba-18ad9dd01217",
                column: "FilePath",
                value: "Images/41f8ee04-f97f-41d8-8cba-18ad9dd01217.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "42d1ebb0-6b86-4b09-ad4f-4f34c189b01c",
                column: "FilePath",
                value: "Images/42d1ebb0-6b86-4b09-ad4f-4f34c189b01c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "42fb9716-1e61-4e4f-ae83-e8043b6c9ba0",
                column: "FilePath",
                value: "Images/42fb9716-1e61-4e4f-ae83-e8043b6c9ba0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4369891f-6ffc-4227-b3f2-4ec660ea74b9",
                column: "FilePath",
                value: "Images/4369891f-6ffc-4227-b3f2-4ec660ea74b9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4588eab1-c87c-4661-9ddc-8d9c9de8c4b8",
                column: "FilePath",
                value: "Images/4588eab1-c87c-4661-9ddc-8d9c9de8c4b8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "490f8038-9bad-4180-a0d2-39e9e9f6292f",
                column: "FilePath",
                value: "Images/490f8038-9bad-4180-a0d2-39e9e9f6292f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "49eb0ef2-158b-4d65-a292-1c133a777621",
                column: "FilePath",
                value: "Images/49eb0ef2-158b-4d65-a292-1c133a777621.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4a338c8d-2537-4766-8c67-f4446ff478f2",
                column: "FilePath",
                value: "Images/4a338c8d-2537-4766-8c67-f4446ff478f2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "4f9f15d2-126e-4ac9-9cea-1fe8b9e86f97",
                column: "FilePath",
                value: "Images/4f9f15d2-126e-4ac9-9cea-1fe8b9e86f97.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "503a5bdb-be29-4da5-9440-5022c33f36ac",
                column: "FilePath",
                value: "Images/503a5bdb-be29-4da5-9440-5022c33f36ac.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "50ec92b2-38ee-4b77-a52c-7cbab6b3f7ac",
                column: "FilePath",
                value: "Images/50ec92b2-38ee-4b77-a52c-7cbab6b3f7ac.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "51de09d5-30ae-45d1-ba22-0000251ca087",
                column: "FilePath",
                value: "Images/51de09d5-30ae-45d1-ba22-0000251ca087.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5267ec91-ad23-4a73-9fde-20271907e089",
                column: "FilePath",
                value: "Images/5267ec91-ad23-4a73-9fde-20271907e089.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5366937c-e4fd-4147-b88b-d42cdc5a214a",
                column: "FilePath",
                value: "Images/5366937c-e4fd-4147-b88b-d42cdc5a214a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5474f429-2dc7-40ec-9af1-7a81c24db43f",
                column: "FilePath",
                value: "Images/5474f429-2dc7-40ec-9af1-7a81c24db43f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "54bbd9b8-16f4-41a5-895a-2395549fb8ca",
                column: "FilePath",
                value: "Images/54bbd9b8-16f4-41a5-895a-2395549fb8ca.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "574ed2e4-cdec-4133-a588-5241c263f6b8",
                column: "FilePath",
                value: "Images/574ed2e4-cdec-4133-a588-5241c263f6b8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "589ede3e-390d-4395-9bf3-799bfaf06701",
                column: "FilePath",
                value: "Images/589ede3e-390d-4395-9bf3-799bfaf06701.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5c73024d-d613-4fae-9873-0e88ff7289c8",
                column: "FilePath",
                value: "Images/5c73024d-d613-4fae-9873-0e88ff7289c8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5d956bf3-d052-44bf-ae8f-29e945da2bb9",
                column: "FilePath",
                value: "Images/5d956bf3-d052-44bf-ae8f-29e945da2bb9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "5f206e19-dea7-4c40-91e7-852458e61831",
                column: "FilePath",
                value: "Images/5f206e19-dea7-4c40-91e7-852458e61831.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "616f99ab-d19f-43cb-9743-f62376b7cd10",
                column: "FilePath",
                value: "Images/616f99ab-d19f-43cb-9743-f62376b7cd10.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "6625b408-607b-48d2-91d8-356ba3e684dd",
                column: "FilePath",
                value: "Images/6625b408-607b-48d2-91d8-356ba3e684dd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "66986a8c-76fb-4626-a2b7-93b4d4aae61f",
                column: "FilePath",
                value: "Images/66986a8c-76fb-4626-a2b7-93b4d4aae61f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "66d9eb05-c031-4e76-bb69-0c650657ff94",
                column: "FilePath",
                value: "Images/66d9eb05-c031-4e76-bb69-0c650657ff94.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "71db4dae-fa71-4311-84b5-ea7b29fcf5fa",
                column: "FilePath",
                value: "Images/71db4dae-fa71-4311-84b5-ea7b29fcf5fa.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "729cfb1b-62fd-4a7f-a11c-b073bd0d8969",
                column: "FilePath",
                value: "Images/729cfb1b-62fd-4a7f-a11c-b073bd0d8969.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "7580baab-5081-45a2-b227-787ab2263775",
                column: "FilePath",
                value: "Images/7580baab-5081-45a2-b227-787ab2263775.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "76f054da-5ffc-4fe3-aa6b-8d6743cf83a9",
                column: "FilePath",
                value: "Images/76f054da-5ffc-4fe3-aa6b-8d6743cf83a9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "77eaf7c6-e81d-4338-be23-a6d84ceb04ca",
                column: "FilePath",
                value: "Images/77eaf7c6-e81d-4338-be23-a6d84ceb04ca.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "7a8ba6fe-03d7-485e-b3af-8cdeec70d067",
                column: "FilePath",
                value: "Images/7a8ba6fe-03d7-485e-b3af-8cdeec70d067.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "7d963661-04f6-43ae-a1e8-f314b597627d",
                column: "FilePath",
                value: "Images/7d963661-04f6-43ae-a1e8-f314b597627d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "824fc1f4-6e52-4776-9ca5-e42e54e68e69",
                column: "FilePath",
                value: "Images/824fc1f4-6e52-4776-9ca5-e42e54e68e69.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "83f98923-0661-44ee-b1aa-be4411619690",
                column: "FilePath",
                value: "Images/83f98923-0661-44ee-b1aa-be4411619690.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "852824a2-c4bd-4582-8f74-9e02667cd57a",
                column: "FilePath",
                value: "Images/852824a2-c4bd-4582-8f74-9e02667cd57a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "85a78cf1-d5af-4363-a2a2-13837485f50f",
                column: "FilePath",
                value: "Images/85a78cf1-d5af-4363-a2a2-13837485f50f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "868302ff-1931-4b03-9afe-9c3c321dcb3b",
                column: "FilePath",
                value: "Images/868302ff-1931-4b03-9afe-9c3c321dcb3b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8982521c-bcd4-4ee4-a712-6085d687e588",
                column: "FilePath",
                value: "Images/8982521c-bcd4-4ee4-a712-6085d687e588.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8ca5997f-53fe-4bf4-8af9-e95994dbb61d",
                column: "FilePath",
                value: "Images/8ca5997f-53fe-4bf4-8af9-e95994dbb61d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8f833fa0-8648-4f0c-bd2f-914fa872ff6a",
                column: "FilePath",
                value: "Images/8f833fa0-8648-4f0c-bd2f-914fa872ff6a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "8fd47fe2-a487-4fce-9c1b-427de0af5d9e",
                column: "FilePath",
                value: "Images/8fd47fe2-a487-4fce-9c1b-427de0af5d9e.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "91cd8cd7-0b1f-4ad7-a9e2-efe029133c78",
                column: "FilePath",
                value: "Images/91cd8cd7-0b1f-4ad7-a9e2-efe029133c78.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "926a0cc9-f77f-4d38-a4ed-80954038182b",
                column: "FilePath",
                value: "Images/926a0cc9-f77f-4d38-a4ed-80954038182b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "92dd4206-5009-4274-9340-41d101a666ef",
                column: "FilePath",
                value: "Images/92dd4206-5009-4274-9340-41d101a666ef.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "94be617b-2886-4796-a816-e70d8254db5c",
                column: "FilePath",
                value: "Images/94be617b-2886-4796-a816-e70d8254db5c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9650da52-cfd0-4da3-a484-8b5d47b896a0",
                column: "FilePath",
                value: "Images/9650da52-cfd0-4da3-a484-8b5d47b896a0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "984fdc6b-11f3-4b24-ab69-6f4eb853d722",
                column: "FilePath",
                value: "Images/984fdc6b-11f3-4b24-ab69-6f4eb853d722.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "988610ab-3fdb-46b8-883a-511e709c51f9",
                column: "FilePath",
                value: "Images/988610ab-3fdb-46b8-883a-511e709c51f9.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "997a8f8f-9e44-4925-b898-ace5cd35bfcd",
                column: "FilePath",
                value: "Images/997a8f8f-9e44-4925-b898-ace5cd35bfcd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9a4f1cef-e773-4b24-9f8c-c4359001b1dd",
                column: "FilePath",
                value: "Images/9a4f1cef-e773-4b24-9f8c-c4359001b1dd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "9aede4aa-7c74-44d1-a70b-201b79442096",
                column: "FilePath",
                value: "Images/9aede4aa-7c74-44d1-a70b-201b79442096.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a10bdd3e-a845-4cb4-9079-0ec9729cd2ff",
                column: "FilePath",
                value: "Images/a10bdd3e-a845-4cb4-9079-0ec9729cd2ff.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a1554699-e1bf-44d6-83d1-c9196b545703",
                column: "FilePath",
                value: "Images/a1554699-e1bf-44d6-83d1-c9196b545703.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a2b37b1f-827f-4ffd-ad2a-6a4a5ecdd938",
                column: "FilePath",
                value: "Images/a2b37b1f-827f-4ffd-ad2a-6a4a5ecdd938.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a326c01d-f7b2-4f67-9a5d-4944f8960f10",
                column: "FilePath",
                value: "Images/a326c01d-f7b2-4f67-9a5d-4944f8960f10.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a5afb091-9e09-4a84-9f58-e14d3685e1e7",
                column: "FilePath",
                value: "Images/a5afb091-9e09-4a84-9f58-e14d3685e1e7.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a6089e18-0213-4564-a0a1-c3923cc9466f",
                column: "FilePath",
                value: "Images/a6089e18-0213-4564-a0a1-c3923cc9466f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a6cb50fc-d720-438f-b2fb-b2abf73ad1d0",
                column: "FilePath",
                value: "Images/a6cb50fc-d720-438f-b2fb-b2abf73ad1d0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "a8b7d89b-08eb-485f-9059-03fe91ee36d2",
                column: "FilePath",
                value: "Images/a8b7d89b-08eb-485f-9059-03fe91ee36d2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "aa8c05b7-c942-4397-8a17-029c0d8dc875",
                column: "FilePath",
                value: "Images/aa8c05b7-c942-4397-8a17-029c0d8dc875.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "aba175f1-63c2-4725-ae4b-740eecac6bf0",
                column: "FilePath",
                value: "Images/aba175f1-63c2-4725-ae4b-740eecac6bf0.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "abc2b28b-f750-45c4-9ebc-fd8d427a397a",
                column: "FilePath",
                value: "Images/abc2b28b-f750-45c4-9ebc-fd8d427a397a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ac9c897f-0834-4041-b87b-0f3918f6df24",
                column: "FilePath",
                value: "Images/ac9c897f-0834-4041-b87b-0f3918f6df24.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "af776ffc-d3ce-4313-b19d-dcb2a0a09cd4",
                column: "FilePath",
                value: "Images/af776ffc-d3ce-4313-b19d-dcb2a0a09cd4.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b17cdfaf-7c31-4b18-adc9-0dec44672b09",
                column: "FilePath",
                value: "Images/b17cdfaf-7c31-4b18-adc9-0dec44672b09.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b2eb45be-70f3-498e-91d5-e43f7861b47b",
                column: "FilePath",
                value: "Images/b2eb45be-70f3-498e-91d5-e43f7861b47b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b4f70f16-4962-4adb-aa21-cbaae0e369bb",
                column: "FilePath",
                value: "Images/b4f70f16-4962-4adb-aa21-cbaae0e369bb.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b5541707-2e00-45fc-9221-3f940ee50255",
                column: "FilePath",
                value: "Images/b5541707-2e00-45fc-9221-3f940ee50255.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "b69dab00-2857-4555-8d7b-7ae6db195795",
                column: "FilePath",
                value: "Images/b69dab00-2857-4555-8d7b-7ae6db195795.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "bb1cefec-0b96-494e-915c-430b17063192",
                column: "FilePath",
                value: "Images/bb1cefec-0b96-494e-915c-430b17063192.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "bd8bb8e7-1221-466e-8be8-1faaa623f3b4",
                column: "FilePath",
                value: "Images/bd8bb8e7-1221-466e-8be8-1faaa623f3b4.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "be653ffe-93b8-4eeb-a9d3-7c7e8c27ca95",
                column: "FilePath",
                value: "Images/be653ffe-93b8-4eeb-a9d3-7c7e8c27ca95.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "c649c783-fd90-40f1-b15e-1703623ddc8a",
                column: "FilePath",
                value: "Images/c649c783-fd90-40f1-b15e-1703623ddc8a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cc4db4c9-b014-4fa4-891a-85051ad2a631",
                column: "FilePath",
                value: "Images/cc4db4c9-b014-4fa4-891a-85051ad2a631.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cc98fedc-1307-4f2c-a830-c7cb312c9a07",
                column: "FilePath",
                value: "Images/cc98fedc-1307-4f2c-a830-c7cb312c9a07.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cd1621e2-52d4-4190-9b14-70568d0ca2ed",
                column: "FilePath",
                value: "Images/cd1621e2-52d4-4190-9b14-70568d0ca2ed.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cf221477-6c55-4318-8674-ee8a8f02f370",
                column: "FilePath",
                value: "Images/cf221477-6c55-4318-8674-ee8a8f02f370.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cfcf1476-2863-4fe6-a892-8ffb8975b166",
                column: "FilePath",
                value: "Images/cfcf1476-2863-4fe6-a892-8ffb8975b166.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "cfe3ca17-7d35-4897-95a1-22fae8071309",
                column: "FilePath",
                value: "Images/cfe3ca17-7d35-4897-95a1-22fae8071309.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d239df37-50c8-4e9b-a80d-04a1e6a8670a",
                column: "FilePath",
                value: "Images/d239df37-50c8-4e9b-a80d-04a1e6a8670a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d353dbeb-9820-41b0-8e0b-8f3bf1fca1f5",
                column: "FilePath",
                value: "Images/d353dbeb-9820-41b0-8e0b-8f3bf1fca1f5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d3617f44-7666-4563-82c0-d54aa838a954",
                column: "FilePath",
                value: "Images/d3617f44-7666-4563-82c0-d54aa838a954.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d41da59e-ee18-44d2-8304-87a056c76767",
                column: "FilePath",
                value: "Images/d41da59e-ee18-44d2-8304-87a056c76767.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d42d3600-ac00-4976-bb49-681f9d7c4e27",
                column: "FilePath",
                value: "Images/d42d3600-ac00-4976-bb49-681f9d7c4e27.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d4ed8af0-c378-490c-bab2-09a95686808a",
                column: "FilePath",
                value: "Images/d4ed8af0-c378-490c-bab2-09a95686808a.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d4fda4f4-b48f-4da5-a6c9-693a3e3ef73b",
                column: "FilePath",
                value: "Images/d4fda4f4-b48f-4da5-a6c9-693a3e3ef73b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "d767d6bb-e3ab-4fa4-9398-9003de15cc00",
                column: "FilePath",
                value: "Images/d767d6bb-e3ab-4fa4-9398-9003de15cc00.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "da97a2e9-d13e-4c08-bc7b-883c8d492f86",
                column: "FilePath",
                value: "Images/da97a2e9-d13e-4c08-bc7b-883c8d492f86.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "de272047-1790-4f5f-bc74-a79ffb720335",
                column: "FilePath",
                value: "Images/de272047-1790-4f5f-bc74-a79ffb720335.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "e0884d7b-45f0-4484-b72f-4ca35db6936f",
                column: "FilePath",
                value: "Images/e0884d7b-45f0-4484-b72f-4ca35db6936f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "e0b29485-265a-4f85-a3db-1a65df513ae8",
                column: "FilePath",
                value: "Images/e0b29485-265a-4f85-a3db-1a65df513ae8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "eb201225-6593-409b-955b-58603556f34b",
                column: "FilePath",
                value: "Images/eb201225-6593-409b-955b-58603556f34b.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "eb5bad8b-889a-4ebd-9966-145e4f787368",
                column: "FilePath",
                value: "Images/eb5bad8b-889a-4ebd-9966-145e4f787368.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ec07baac-38f2-4d85-b278-7e1c2ed6ece5",
                column: "FilePath",
                value: "Images/ec07baac-38f2-4d85-b278-7e1c2ed6ece5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ec2ac398-5973-4594-a155-e53d3f6b1b1d",
                column: "FilePath",
                value: "Images/ec2ac398-5973-4594-a155-e53d3f6b1b1d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "ed1a380d-d279-427e-89a0-91e9fb56167d",
                column: "FilePath",
                value: "Images/ed1a380d-d279-427e-89a0-91e9fb56167d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "edc756ff-7dec-42c0-8fd6-d6baeeff938f",
                column: "FilePath",
                value: "Images/edc756ff-7dec-42c0-8fd6-d6baeeff938f.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f0eff95f-91ff-4f96-b703-2576a8ab50b5",
                column: "FilePath",
                value: "Images/f0eff95f-91ff-4f96-b703-2576a8ab50b5.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f19aaa80-4cdd-443a-a542-8eeb1320998c",
                column: "FilePath",
                value: "Images/f19aaa80-4cdd-443a-a542-8eeb1320998c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f4c93663-203a-45bf-ae7c-e76ab78dd290",
                column: "FilePath",
                value: "Images/f4c93663-203a-45bf-ae7c-e76ab78dd290.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f68fdafc-f5db-4ab7-94ae-81a09e4f817c",
                column: "FilePath",
                value: "Images/f68fdafc-f5db-4ab7-94ae-81a09e4f817c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f741bca7-e0b3-414d-bdcd-40c0c9ff3cdd",
                column: "FilePath",
                value: "Images/f741bca7-e0b3-414d-bdcd-40c0c9ff3cdd.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f981971f-a887-43ca-b3e2-4f39f613483d",
                column: "FilePath",
                value: "Images/f981971f-a887-43ca-b3e2-4f39f613483d.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "f98b5387-e029-4ab9-8366-f764b5313e4c",
                column: "FilePath",
                value: "Images/f98b5387-e029-4ab9-8366-f764b5313e4c.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fad4f25c-7bb3-4a17-ba18-c9b2969e8852",
                column: "FilePath",
                value: "Images/fad4f25c-7bb3-4a17-ba18-c9b2969e8852.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fcf45d3e-bd42-4e4f-90ce-d37b26f58995",
                column: "FilePath",
                value: "Images/fcf45d3e-bd42-4e4f-90ce-d37b26f58995.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fd700b5d-ae2f-4dae-91ae-46d8f3bf3be2",
                column: "FilePath",
                value: "Images/fd700b5d-ae2f-4dae-91ae-46d8f3bf3be2.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: "fe1a4e59-6541-4d42-ad4a-90094c4b8c97",
                column: "FilePath",
                value: "Images/fe1a4e59-6541-4d42-ad4a-90094c4b8c97.jpg");
        }
    }
}
