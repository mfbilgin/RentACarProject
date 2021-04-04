USE [RentACar]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (1, N'Muhammet', N'Bilgin', 0x7EDDFC8FBF0CE2ABD8423EE60F35776138EC59D39CDB6B706833777FD4E1C174F5176CAB052A7D4EA1F91A291CF63AF716225AB5E70A8F8C5ED1D8488BFC531C00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 0x6FC89288165A2D2E225D5158CE1A4DB2BBF24E33B8EACABA47F683A9738ED564A34CF4A5AC51A66EA5396CEA7A2120C0A2040877AD8022F179E648BD0C48DC4475A941B6CA35394106FDD15CE38343FEF09F2BF852DCA7D3015BA372EBBA07747CA3A7F3D469CDC65FDAA7FD3D3E6C95C239F812C304FDC941386C19C062F157000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, 1, N'mf.bilgin0@gmail.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (2, N'Muhammet Fethullah', N'Bilgin', 0x56B50D0D8FB58E7FA75B4D333C38E0B84C191FB696D2B1ED890FA80A58A74EE35E16B6224080889667522CCCBA0A0939FEB2CB57E7242E059A52BFDBE73CD651, 0xC6E25FAEA4626F9FEFB01565A53290C5DB85042D48BC3EC3CE08BD7AF5F8C5F87A50224BFCE82F9419B23225760C593821BB039F700EAF52AD6C8B76079F34721CCB69FFB973A9DB8BBE3B4FEB6CAD5C6B3651A27E2501071D3E2BB988E6DEE08B6283BB5E6799728DAD9EEC8DB0F57D1FD8556057C3AF2D225BEEA423D93A5C, 1, N'mf.bilgin@gmail.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (3, N'Esra', N'Sancak', 0x0ECBEF2FAD9DE90A86A9CE307BCED50DB7E63D8CA2D5C5D7A37607F0B1B9E0A40D862E4E997AD3B88EF35688C10E3292C86EB6CA9FBF78AE128B65AD8AF600C4, 0x1D90A81A5BE5E8238532ED2E6CAD2E5D3DCD1B71072FD149DD396E0EB9E872B575D48FB0CAB3845853AE8BE4DD1E58288C144F32B16538DC0E5ECCCF18B8CA296425F7017328426AFD60FF761FC9D82A7B3E2E13AEB2C148647ADC862664CF493B425B1E8BA0D3FC098A8E978BD341D33FA1A5E760ED15CFA31DFD35DA887A7B, 1, N'esra@sancak.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (4, N'Kübra', N'Terzi', 0x47D1BCF16EE9C18E16B7BEBB58E991692AE01F93BFAEA4A274DD2BC2E534F97E62D92CA0CB5702266DBD833FA2718FF351156DDBA24E8BE3C52AD0DDDABAD44D, 0x147E1835FDE620EAD26AE5DB1398A6A7EE3DF0C088937DFB147D186A42D209FF9B762D686B3F032594120C0F10EF9F67E007604DD1B5076F6EBBE847829023969F422969C244244B6762D8DACCF17D3BD5BCC6B1931D293C0D7FD6CDC47548AAB9C637254CCF20EABEFF40DFAAF609C77E9CFEE950BFF53B7CAA564918489323, 1, N'kubra@terzi.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (5, N'Kerem', N'Varış', 0x26791DF7EF6C57E4D268EFC5FCF5F96D3785109757221E930B423CF66BA38BB4C03EDB2D7A1DED562BC9CBF9FC41D7A1F0011A187296A23C2D6A40E73D4A1196, 0xF3B6FBEF654F44C3C33EA6C30B0170D1986C9492DC7D49FFDBC2841545B43974F7DD42BC62D4ACA2D65C7B4422760F1395CE4F0B50BCB133A63AD6F3F86CD6F045154DD08081D34930D20C2693025D49DB086ACA2E04DA8538616CFE971443D47C70CD9CBD4A37A6A0FF39AF7A254EA2681D545EE73B964C852D4D8CDB2405C8, 1, N'kerem@varis.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (6, N'Muhammet', N' Fethullah', 0x07BA372655A8D85DA015E1F912F384F88C218510C5BD42E685150DC9B7F8E30DF0E0BD87F49C05A49E8E2D2ECB1DD882FA60C30E0ADF02EB553FE2E2E1BD267C, 0x5BD2BAC64C94DDC79BE7F28BABDCDAAB834D0E4D6DCBECB816A14D6C94F579CF64412A5E716E54AE8B251B639DF87BF6BF3B91167887A758548A9F7DC17D600C7C7406D836B409DD0693632BB7BF7FDFC355FE7B4B047CF5C4DA392D27D36CF1FC152C5BDD79A6C73FF547EB399365AB25BD8747A34520D7F94F04BCCD4FA550, 1, N'mf.bilginn@gmail.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (7, N'Murat', N'Kurtboğan', 0x8DDC83D2D4F161A4F5B6C10A474BCF3E48132CC0BDDB74CC1008D77510A33C98604AB9192AE4B160B981BB8451C7E42597392133E68C67B980D1A43101B1BA64, 0x2A4B80ACFE58F4CCBFA2566E6D21DD2B1017C29EE6FE0ACF6CF4991C8838BC37E4231E136B7BF5AF65FCD05180A4FD77F24BB42F468D327B835401E0C2BA52C3F538D2E1166B346717EBB3E902DC13E1F0B37700038D9EE80F4263EB27378AAD28E6255A216F52FFE4E58E6783034CB7F41189AC194B92CA623902FEA01455F0, 1, N'murat@kurtbogan.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (8, N'Mehmet', N'Yılmaz', 0x8BFB9FCEC49671A2E09983F5E6D22C75D83AD1AFD1421154EBD217913887697E4FA83BF907C9E78372A0A26BA6BE7074733466516B8E45212D26DD9B1C951A1F, 0x1114633FE36B4246533E9992D9C04811B265C43788E724F8E755B7FC8D7E707874C7B9C0E82973195A4DB994DA48A10A2B4D1E7E078486F769518DC1E6835184FDD97F7159ADF5F00E5329E0238970A1C27005CED0AED02082CFCA1EC8DC6F2CAB37C83CB2A7A75E185B2D75EB47599BACB79C37D4A49B8F38D953A3A8B583FE, 1, N'mehmet@yılmaz.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (9, N'Mehmet', N'Yılmaz', 0x54EB31DE518A0D047F31DD8173162EB3B68757D2930771157BEA9F8084CFC8F0A71640B105706A602AF2B3188DDC96D31DCAADA56D6406FBCBDF7AE917552CAE, 0x0FEAD8763D1F6ABBC98916D6D097C7EA7031DD526EBAE55492793997F1A37FE7CB2C870126FAE8C8CD8B9F27C18048AF78165F172AAC3500C06077458B4CDE324F465AEAEFB4459E8E794EB17BB294845E05BB4F941364E1178A8669039997BE2FF6852986C939BD6C5D6FBBE8EB38217B7DF01DDF7382A81ACA86A1FC203AA0, 1, N'mehmet@gmail.com', 0)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (10, N'Ahmet', N'Yaşar', 0xF121230BDEA61D01699FD858AB80B60E8E85D31320029330E6EAC29CE211F22535426126FC53D5C2DCFB1BB7A7DEE7A7E71793FFDF30AF91F1DE1D9B537FED98, 0x48F64CBDC3999D598A2CC31C78682044418EC594FD50B74635C3303D69099A70B8650BCC182666BECBD0E2A6192E1B115CB3F16E6AFFECCEC313E216FA27E8149D630C7FD7C86276C7E16332405B9E7CFBE62F6BB7E8B1945E5508FD0009FCE66BEBD8ED3176BF374E5BC96DFB63ACEBB3A2A5441152E6F3E2759C3CF3170A8F, 1, N'ahmet.yasar@gmail.com', 300)
INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [PasswordHash], [PasswordSalt], [Status], [Email], [FindexPoint]) VALUES (11, N'Fatih', N'Demir', 0xAC50C06F353A79675A730557453F553B8C062478083AE2803E63CCE00CF48EC0F14E6A2AB41406EE31CB42A2409FB5660F9E11490B8A3DBD9976812BD7554AA8, 0xCF497E4D2661F8B51CC2E27EE21DBD57EFDD7C2F7277A4DF62F365AD02360D58B44E99E967477EC06876B3C66D793147D46613013B8167B89DD03A9BAF0CA06CE3C418A4EECF688234E5EBDE0606DEA5BDD757F963B050D6F0A09FA6564A6FEB9717E260240CF09C64603185C07A0A8AC1CCD97344D52FE8D55DABA400319E97, 1, N'fatih@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (1, N'Beyaz')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (2, N'Sarı')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (3, N'Kırmızı')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (4, N'Mavi')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (5, N'Siyah')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (6, N'Yeşil')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (7, N'Turuncu')
INSERT [dbo].[Colors] ([ColorId], [ColorName]) VALUES (8, N'Gri')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Brands] ON 

INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (1, N'Tesla')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (2, N'Ferrari')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (3, N'Audi')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (4, N'Toyota')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (5, N'Mercedes')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (6, N'Volkswagen')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (7, N'Lamborghini')
INSERT [dbo].[Brands] ([BrandId], [BrandName]) VALUES (8, N'Mini')
SET IDENTITY_INSERT [dbo].[Brands] OFF
GO
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (1, 1, 1, 2020, 800, N'Tesla Model X', N'Tesla', 200)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (2, 1, 3, 2019, 750, N'Tesla Model S', N'Tesla', 200)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (3, 1, 8, 2021, 1150, N'Tesla Model 3', N'Tesla', 200)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (4, 2, 3, 2019, 1400, N'Ferrari F430', N'Ferrari', 750)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (5, 3, 1, 2019, 500, N'Audi A6', N'Audi', 500)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (6, 4, 4, 2014, 300, N'Toyota Verso', N'Toyota', 0)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (7, 5, 5, 2020, 700, N'Mercedes 200 AMG', N'Mercedes', 350)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (8, 6, 2, 2020, 470, N'Volkswagen Tiguan', N'Volkswagen', 0)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (9, 7, 7, 2016, 2500, N'Lamborghini Aventador', N'Lamborgihini', 900)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (10, 8, 6, 2018, 490, N'Mini Cooper', N'Mini', 100)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (11, 1, 3, 2020, 900, N'Tesla Model Y', N'Tesla', 200)
INSERT [dbo].[Cars] ([CarId], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Descript], [BrandName], [MinFindex]) VALUES (12, 5, 8, 2009, 2500, N'Mercedes Vision Avtr', N'Mercedes', 900)
SET IDENTITY_INSERT [dbo].[Cars] OFF
GO
SET IDENTITY_INSERT [dbo].[Rentals] ON 

INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate], [UserId]) VALUES (1, 6, 10, CAST(N'2021-04-03T00:00:00.000' AS DateTime), CAST(N'2021-04-04T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate], [UserId]) VALUES (3, 8, 10, CAST(N'2021-04-10T00:00:00.000' AS DateTime), CAST(N'2021-04-18T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate], [UserId]) VALUES (4, 1, 10, CAST(N'2021-04-03T00:00:00.000' AS DateTime), CAST(N'2021-04-05T00:00:00.000' AS DateTime), 10)
INSERT [dbo].[Rentals] ([RentalId], [CarId], [CustomerId], [RentDate], [ReturnDate], [UserId]) VALUES (5, 2, 10, CAST(N'2021-04-04T00:00:00.000' AS DateTime), CAST(N'2021-04-05T00:00:00.000' AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[Rentals] OFF
GO
SET IDENTITY_INSERT [dbo].[OperationClaims] ON 

INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (1, N'admin')
INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (2, N'add')
INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (3, N'moderator')
INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (4, N'list')
INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (5, N'color.add')
INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (6, N'brand.add')
INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (7, N'car.add')
INSERT [dbo].[OperationClaims] ([OperationClaimId], [OperationClaimName]) VALUES (8, N'image.add')
SET IDENTITY_INSERT [dbo].[OperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[UserOperationClaims] ON 

INSERT [dbo].[UserOperationClaims] ([UserOperationClaimId], [UserId], [OperationClaimId]) VALUES (1, 1, 1)
INSERT [dbo].[UserOperationClaims] ([UserOperationClaimId], [UserId], [OperationClaimId]) VALUES (2, 2, 1)
INSERT [dbo].[UserOperationClaims] ([UserOperationClaimId], [UserId], [OperationClaimId]) VALUES (3, 1, 8)
INSERT [dbo].[UserOperationClaims] ([UserOperationClaimId], [UserId], [OperationClaimId]) VALUES (4, 2, 8)
SET IDENTITY_INSERT [dbo].[UserOperationClaims] OFF
GO
SET IDENTITY_INSERT [dbo].[SavedDebitCard] ON 

INSERT [dbo].[SavedDebitCard] ([SavedDebitCardId], [CardholderName], [CardholderLastName], [CardNumber], [Cvv], [ExpirationDate], [UserId]) VALUES (2, N'Ahmet', N'Yaşar', N'4725412387496325', N'748', N'06/28', 10)
SET IDENTITY_INSERT [dbo].[SavedDebitCard] OFF
GO
SET IDENTITY_INSERT [dbo].[CarImages] ON 

INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (1, 1, N'/images/3df48295-95d0-4001-8e33-416d0649b9f9.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (2, 2, N'/images/e5041d40-5647-4655-bccd-f8f0862ece47.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (3, 3, N'/images/269e7a3b-cc0e-47ff-8bfe-f84992ddd483.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (4, 4, N'/images/6b6eef12-30d5-491e-b47e-f0f0179d774d.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (5, 5, N'/images/7e9ef629-7491-4945-85f4-754d0a8688e3.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (6, 6, N'/images/1af49bbb-aac4-4a8c-8299-3dbe2191d9e2.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (7, 7, N'/images/3d2c5641-0f2d-4c27-9d5d-8319a48bf66d.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (8, 8, N'/images/d4b5c02f-ac3d-4f6d-82e2-67e395042b00.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (9, 9, N'/images/1ebc9dce-bad7-46b5-8afa-90653fd9e551.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (10, 10, N'/images/0d09f153-1747-4a6f-b6ba-8d6b8601fc89.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (11, 11, N'/images/ca5c61ff-8753-4f64-af46-d3b3d9f788f0.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (12, 1, N'/images/aa050835-bade-4859-a356-acdbe4c32589.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (13, 1, N'/images/cffaeecd-300b-4431-9b90-02c28b1ab4f4.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (14, 2, N'/images/c8dabdd8-11ae-4b79-9c47-a03056e4a559.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (15, 2, N'/images/ce5a3f7d-a4cf-418d-b448-16026d0730e4.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (16, 3, N'/images/6af7dcfb-0682-4849-bc3c-d1cb36c11f25.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (17, 3, N'/images/fdc9b034-9c1a-4df5-9031-68947376547b.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (18, 4, N'/images/30057621-7b40-4a04-8ccb-04e94d67087e.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (19, 4, N'/images/fd9b765a-a269-4317-a770-3675ec315075.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (20, 5, N'/images/dfa30cca-9dae-47e6-9e0e-3b12810f9db1.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (21, 5, N'/images/4da82cc5-930e-47ef-9cf0-7f85f7009357.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (22, 6, N'/images/dead5a9b-746c-4002-9ca5-8222fc169b16.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (23, 6, N'/images/9d95f895-00fd-4fa1-a535-b912b5af1495.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (26, 12, N'/images/02c24f11-6b2c-4150-a2db-255b9af8c8d8.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (27, 7, N'/images/ce29b22f-03af-40ae-b5e2-088fd75d0831.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (28, 7, N'/images/686bfec1-4a82-4e41-940f-f075ebec3af1.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (29, 8, N'/images/523632ca-056a-4979-81e4-54d8edaf6aba.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (30, 8, N'/images/64d8a926-e379-404b-aa34-a00dce3d1538.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (31, 9, N'/images/74a2f537-edf6-46e1-a006-526da0db9181.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (32, 9, N'/images/46abee44-d670-4aa4-b758-79f1b4c1cce9.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (33, 10, N'/images/d3c0fe24-eac0-4a5a-8b04-6957c17a6ade.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (34, 10, N'/images/f26101ae-c5ad-4aa6-9729-c990a16e92ac.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (35, 11, N'/images/89f0803d-8281-475e-b274-0dfb49b9f607.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (36, 11, N'/images/293669d3-0bcd-44dd-97d0-c6333ee63919.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (37, 12, N'/images/f236c85a-9824-4cc9-9ab3-d9cea102a0ad.jpg', NULL)
INSERT [dbo].[CarImages] ([Id], [CarId], [ImagePath], [Date]) VALUES (38, 12, N'/images/502d62e5-6b19-4d99-9483-828dd53630aa.jpg', NULL)
SET IDENTITY_INSERT [dbo].[CarImages] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (1, 1, N'MFBILGIN')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (2, 2, N'KodlamaIo')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (3, 3, N'PairAS')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (4, 4, N'PaiAS')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (5, 5, N'ModAS')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (6, 7, N'KodlamaIO')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (7, 9, N'TestAS')
INSERT [dbo].[Customers] ([CustomerId], [UserId], [CompanyName]) VALUES (10, 10, N'TestAS')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[DebitCards] ON 

INSERT [dbo].[DebitCards] ([DebitCardId], [CardNumber], [CVV], [ExpirationDate], [Balance], [CardholderName], [CardholderLastName]) VALUES (1, N'1234567891234567', N'159', N'02/24', 5000.0000, N'Muhammet Fethullah', N'Bilgin')
INSERT [dbo].[DebitCards] ([DebitCardId], [CardNumber], [CVV], [ExpirationDate], [Balance], [CardholderName], [CardholderLastName]) VALUES (2, N'4725412387496325', N'748', N'06/28', 973.0000, N'Ahmet', N'Yılmaz')
INSERT [dbo].[DebitCards] ([DebitCardId], [CardNumber], [CVV], [ExpirationDate], [Balance], [CardholderName], [CardholderLastName]) VALUES (3, N'3576120745343569', N'865', N'07/28', 7000.0000, N'Mehmet', N'Yıldız')
INSERT [dbo].[DebitCards] ([DebitCardId], [CardNumber], [CVV], [ExpirationDate], [Balance], [CardholderName], [CardholderLastName]) VALUES (4, N'4345764270964453', N'231', N'01/26', 12000.0000, N'Ayşe', N'Güner')
SET IDENTITY_INSERT [dbo].[DebitCards] OFF
GO
