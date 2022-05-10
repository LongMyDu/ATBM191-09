
-- INSERT DATA CHUYEN KHOA
INSERT INTO CHUYENKHOA(MAKHOA,TENKHOA) VALUES ('K00001',N'Thần kinh');
INSERT INTO CHUYENKHOA(MAKHOA,TENKHOA) VALUES ('K00002',N'Ung thư');
INSERT INTO CHUYENKHOA(MAKHOA,TENKHOA) VALUES ('K00003',N'Tai, mũi, họng');
INSERT INTO CHUYENKHOA(MAKHOA,TENKHOA) VALUES ('K00004',N'Trẻ em');

-- INSERT DATA DICHVU
INSERT INTO DICHVU(MADV,TENDICHVU) VALUES ('DV0001',N'Xét nghiệm huyết học');
INSERT INTO DICHVU(MADV,TENDICHVU) VALUES ('DV0002',N'Xét nghiệm sinh hóa');
INSERT INTO DICHVU(MADV,TENDICHVU) VALUES ('DV0003',N'Siêu âm');
INSERT INTO DICHVU(MADV,TENDICHVU) VALUES ('DV0004',N'CT');
INSERT INTO DICHVU(MADV,TENDICHVU) VALUES ('DV0005',N'Chụp X-Quang');

-- INSERT DATA TO CSYT
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0001',N'Bệnh viện đa khoa Vạn Hạnh',N'700 Sư Vạn Hạnh (nối dài) - P 12 – Quận 10 - TP.HCM', '0986875637');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0002',N'Bệnh viện Tân Sơn Nhất',N'2B Phổ Quang - P2 - Quận Tân Bình - TP.HCM', '0902318877');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0003',N'Bệnh viện đa khoa Tân Hưng ',N'871 Trần Xuân Soạn - P. Tân Hưng - Quận 7 - TP.HCM', '0913777399');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0004',N'Bệnh viện Thống Nhất',N'01 Lý Thường Kiệt – Phường 7 - Quận Tân Bình - TP.HCM', '0966821010');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0005',N'Bệnh viện 175',N'786 Nguyễn Kiệm- P. 3- Quận Gò vấp - TP.HCM', '0984795351');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0006',N'Bệnh viện Nguyễn Tri Phương',N'468 Nguyễn Trãi – Phường 8 – Quận 5 - TP.HCM', '0931427504');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0007',N'Bệnh viện Nhân dân Gia Định',N'01 Nơ Trang Long – Phường 7 – Quận Bình Thạnh - TP.HCM', '0902418869');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0008',N'Bệnh viện nhân dân 115',N'527 Sư Vạn Hạnh – Phường 12 – Quận 10 - TP.HCM', '0907527643');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0009',N'Bệnh viện đa khoa Sài Gòn',N'125 Lê Lợi – Phường Bến Thành – Quận 1 - TP.HCM', '0902963115');
INSERT INTO CSYT(MACSYT, TENCSYT, DCCSYT, SDTCSYT) VALUES ('CS0010',N'Bệnh viện Quân Dân Miền Đông ',N'50 Lê Văn Việt – Phường Hiệp Phú - Quận 9 - TP.HCM', '0908376664');

--INSERT DATA TO NHANVIEN
EXEC THEMNHANVIEN('NV0001',N'Hoàng Việt Ly Yến', N'Nam', '1996-03-25','410963698240', N'Cần Thơ', '0868706271', 'CS0002', N'Thanh tra', NULL, 'BKbhjoLwF');
EXEC THEMNHANVIEN('NV0002',N'Huỳnh Ung Trang Bích', N'Nam', '1941-06-08','917138329545', N'TP.HCM', '0777009958', 'CS0003', N'Thanh tra', NULL, 'eGic8rbcx4y8');
EXEC THEMNHANVIEN('NV0003',N'Ong Ngọc Thương Nhung', N'Nữ', '1966-09-13','829252737656', N'TP.HCM', '0568555736', 'CS0004', N'Thanh tra', NULL, 'I3WkHkUue0iWh0cKqLXZ');
EXEC THEMNHANVIEN('NV0004',N'Long Nhật Bách Khuê', N'Nữ', '1961-06-28','758234874761', N'Cần Thơ', '0853790250', 'CS0005', N'Thanh tra', NULL, 'nYw3w67r96rMGl');
EXEC THEMNHANVIEN('NV0005',N'Ong Thành Nhã Thùy', N'Nữ', '1999-11-24','084456993664', N'Tây Ninh', '0708257974', 'CS0006', N'Thanh tra', NULL, 'A1OtvcN6');
EXEC THEMNHANVIEN('NV0006',N'Dương Nguyệt Dương Diệp', N'Nữ', '1966-06-07','675756075261', N'Cần Thơ', '0912898972', 'CS0002', N'Cơ sở y tế', NULL, 'UGtnUsdJn');
EXEC THEMNHANVIEN('NV0007',N'Phan Việt Dương', N'Nam', '1971-04-01','859242462428', N'Bắc Ninh', '0917122786', 'CS0003', N'Cơ sở y tế', NULL, 'JHqdairxs0n30xYE7b8L');
EXEC THEMNHANVIEN('NV0008',N'Danh Mỹ Kiều Dũng', N'Nữ', '1920-05-12','486589763960', N'Trà Vinh', '0707366416', 'CS0004', N'Cơ sở y tế', NULL, 'Ry2ilPNCd');
EXEC THEMNHANVIEN('NV0009',N'Dương Văn Kiều', N'Nam', '1928-05-07','503192156214', N'TP.HCM', '0580239368', 'CS0005', N'Cơ sở y tế', NULL, 'XUN9dtjXxzlkF');
EXEC THEMNHANVIEN('NV0010',N'Long Việt Mai', N'Nam', '1972-07-20','770179263005', N'TP.HCM', '0982362318', 'CS0006', N'Cơ sở y tế', NULL, 'sGie8ylOkstWssz7uxr');
EXEC THEMNHANVIEN('NV0011',N'Trịnh Ung Hoa Ngọc', N'Nam', '1966-01-27','626511554232', N'Bắc Ninh', '0813439746', 'CS0007', N'Cơ sở y tế', NULL, 'dTpLplx238');
EXEC THEMNHANVIEN('NV0012',N'Vũ Nguyệt Hùng Đào', N'Nam', '2000-02-13','088272820825', N'Bắc Ninh', '0394816194', 'CS0008', N'Cơ sở y tế', NULL, 'yPCGMZxJgwdkS');
EXEC THEMNHANVIEN('NV0013',N'Đỗ Hồng Dương', N'Nam', '1946-10-13','651823963095', N'Tây Ninh', '0852379891', 'CS0009', N'Cơ sở y tế', NULL, 'xl6BinNNGTlx7ZCR');
EXEC THEMNHANVIEN('NV0014',N'Ngô Ung Lam', N'Nữ', '1929-01-27','705720922190', N'Tây Ninh', '0707923753', 'CS0010', N'Cơ sở y tế', NULL, 'mEsJ6otxMmViOV9');
EXEC THEMNHANVIEN('NV0015',N'Danh Thành Hiếu', N'Nữ', '1938-11-04','287673062535', N'Bắc Ninh', '0936096970', 'CS0001', N'Cơ sở y tế', NULL, '6PyyBIQwB7mY4RUFmTw');
EXEC THEMNHANVIEN('NV0016',N'Dương Nhật Anh Đan', N'Nữ', '1948-10-21','313847922476', N'Trà Vinh', '0334143857', 'CS0002', N'Cơ sở y tế', NULL, 'mV8aYHZ42g');
EXEC THEMNHANVIEN('NV0017',N'Võ Hà Lan Tường', N'Nam', '1923-10-22','196893690493', N'Bến Tre', '0923272746', 'CS0003', N'Cơ sở y tế', NULL, 'zCjQrUjWJV6X');
EXEC THEMNHANVIEN('NV0018',N'Lê Văn Anh Mi', N'Nữ', '1972-03-04','324913323649', N'Bến Tre', '0852479653', 'CS0004', N'Cơ sở y tế', NULL, 'xAG84tP2MkK5Yb4Y9sW');
EXEC THEMNHANVIEN('NV0019',N'Đỗ Nguyệt Lan', N'Nữ', '1956-08-16','792452447502', N'TP.HCM', '0854400196', 'CS0005', N'Cơ sở y tế', NULL, 'MllnZVIrRjT');
EXEC THEMNHANVIEN('NV0020',N'Đỗ Bửu Tâm', N'Nữ', '1953-08-17','803019783337', N'Bắc Ninh', '0894130374', 'CS0006', N'Cơ sở y tế', NULL, 'AGufO8AM4j36FHy6oWiK');
EXEC THEMNHANVIEN('NV0021',N'Lê Khánh Gia', N'Nữ', '1976-12-06','031900361300', N'Bến Tre', '0862577631', 'CS0007', N'Cơ sở y tế', NULL, 'T0jL3y0uB');
EXEC THEMNHANVIEN('NV0022',N'Long Thành Cường', N'Nam', '1971-05-17','648537445435', N'TP.HCM', '0767367110', 'CS0008', N'Cơ sở y tế', NULL, 'r1AMpJHUeQth2w');
EXEC THEMNHANVIEN('NV0023',N'Lê Văn Chi', N'Nữ', '1956-08-18','997835560317', N'Cần Thơ', '0860428138', 'CS0009', N'Cơ sở y tế', NULL, 'lfWvzBB5g');
EXEC THEMNHANVIEN('NV0024',N'Âu Dương Ngọc Băng Bách', N'Nam', '1928-10-31','931361921026', N'Cần Thơ', '0941997450', 'CS0010', N'Cơ sở y tế', NULL, 'w3pByh44jxb6yJGJF2');
EXEC THEMNHANVIEN('NV0025',N'Chung Hồng Hạnh', N'Nam', '1969-05-22','580295250641', N'Trà Vinh', '0776807904', 'CS0001', N'Cơ sở y tế', NULL, 'HtDNARYew0f8hlTFjFi');
EXEC THEMNHANVIEN('NV0026',N'Ung Khánh Bảo Linh', N'Nữ', '1965-07-20','865766193037', N'Bắc Ninh', '0837638318', 'CS0002', N'Y sĩ/ bác sĩ', N'Thần kinh', 'jnPygRZRUNO8M2tbpSf');
EXEC THEMNHANVIEN('NV0027',N'Nguyễn Bửu Đạt Thương', N'Nữ', '1953-06-18','478136075046', N'Trà Vinh', '0352527833', 'CS0003', N'Y sĩ/ bác sĩ', N'Ung thư', 'Ume4LWkh2ZrFjmYr');
EXEC THEMNHANVIEN('NV0028',N'Ung Nguyệt Ân', N'Nam', '1978-11-07','799272390265', N'TP.HCM', '0997877977', 'CS0004', N'Y sĩ/ bác sĩ', N'Tai, mũi, họng', 'IYEuwRKyyN9KNjU');
EXEC THEMNHANVIEN('NV0029',N'Lý Phúc Thi Oanh', N'Nam', '1938-07-25','740214271755', N'Bến Tre', '0334418130', 'CS0005', N'Y sĩ/ bác sĩ', N'Trẻ em', 'VWgbzIuWn6UnzBeC');
EXEC THEMNHANVIEN('NV0030',N'Phạm Hồng Hiền', N'Nam', '1986-03-16','557610679443', N'Cần Thơ', '0348890371', 'CS0006', N'Y sĩ/ bác sĩ', N'Thần kinh', 'GsNbEzmTGt2bjWVo9ZNa');
EXEC THEMNHANVIEN('NV0031',N'Phan Ung Đức Thủy', N'Nữ', '1936-01-18','814924308375', N'TP.HCM', '0913081560', 'CS0007', N'Y sĩ/ bác sĩ', N'Ung thư', 'rhLDh0u0e');
EXEC THEMNHANVIEN('NV0032',N'Ung Hồng Nguyệt Dũng', N'Nam', '1999-09-12','734664302041', N'TP.HCM', '0849950204', 'CS0008', N'Y sĩ/ bác sĩ', N'Tai, mũi, họng', 'FgJcBU2Oqg8bSnB9FX');
EXEC THEMNHANVIEN('NV0033',N'Long Anh Khanh', N'Nam', '1922-02-26','427628358443', N'Cần Thơ', '0816892197', 'CS0009', N'Y sĩ/ bác sĩ', N'Trẻ em', '4pAC9xTSkE0K7dS1TMl');
EXEC THEMNHANVIEN('NV0034',N'Chung Mỹ Ánh', N'Nam', '1939-12-11','459171471634', N'Bắc Ninh', '0977309581', 'CS0010', N'Y sĩ/ bác sĩ', N'Thần kinh', 'ealGrGlmnj5gG');
EXEC THEMNHANVIEN('NV0035',N'Ngô Anh Thơ Đạt', N'Nam', '1984-01-26','453679954272', N'Trà Vinh', '0377310732', 'CS0001', N'Y sĩ/ bác sĩ', N'Ung thư', 'GkyhqaYI9qvmxL8EL');
EXEC THEMNHANVIEN('NV0036',N'Hứa Văn Diễm Khanh', N'Nam', '1944-06-29','399981059659', N'Bến Tre', '0774786336', 'CS0002', N'Y sĩ/ bác sĩ', N'Tai, mũi, họng', '8TOsQ9Bl0GShuFMHu');
EXEC THEMNHANVIEN('NV0037',N'Long Hà Khanh', N'Nữ', '1988-12-26','108914194564', N'Bắc Ninh', '0584051057', 'CS0003', N'Y sĩ/ bác sĩ', N'Trẻ em', '3SsNVz4HyPPM1jy2');
EXEC THEMNHANVIEN('NV0038',N'Nguyễn Văn Thủy', N'Nam', '1964-06-07','435425344998', N'Bến Tre', '0920654178', 'CS0004', N'Y sĩ/ bác sĩ', N'Thần kinh', '6IeWAPa4IhMs4l');
EXEC THEMNHANVIEN('NV0039',N'Lý Khánh Ngọc Tâm', N'Nữ', '1934-07-22','203322515882', N'TP.HCM', '0367398160', 'CS0005', N'Y sĩ/ bác sĩ', N'Ung thư', 'TlUbEnXo');
EXEC THEMNHANVIEN('NV0040',N'Chung Thị Băng Đức', N'Nam', '1929-06-10','747376189404', N'Tây Ninh', '0964288303', 'CS0006', N'Y sĩ/ bác sĩ', N'Tai, mũi, họng', 'MqXqw5eWyNYx87klTr');
EXEC THEMNHANVIEN('NV0041',N'Huỳnh Thị Dung', N'Nữ', '1978-03-21','041006808743', N'Trà Vinh', '0978239102', 'CS0007', N'Y sĩ/ bác sĩ', N'Trẻ em', 'eaCigJVb');
EXEC THEMNHANVIEN('NV0042',N'Dương Văn Thùy Đức', N'Nữ', '1965-07-23','529609359645', N'Bến Tre', '0819822713', 'CS0008', N'Y sĩ/ bác sĩ', N'Thần kinh', 'tGiHJ6On9w5U6Z4a');
EXEC THEMNHANVIEN('NV0043',N'Danh Tân Mi', N'Nữ', '1970-11-12','076110272515', N'Trà Vinh', '0981655748', 'CS0009', N'Y sĩ/ bác sĩ', N'Ung thư', 'Sp0JrMPKqiGf');
EXEC THEMNHANVIEN('NV0044',N'Âu Dương Hồng Mi', N'Nam', '1970-10-13','465442648845', N'Trà Vinh', '0333117275', 'CS0010', N'Y sĩ/ bác sĩ', N'Tai, mũi, họng', '8kDqvS6L94');
EXEC THEMNHANVIEN('NV0045',N'Bùi Ung Huyền', N'Nam', '1967-10-09','341370236279', N'Cần Thơ', '0971522668', 'CS0001', N'Y sĩ/ bác sĩ', N'Trẻ em', 'CgcI4ndk');
EXEC THEMNHANVIEN('NV0046',N'Long Văn Nguyệt Nguyệt', N'Nam', '1941-11-28','491646195877', N'TP.HCM', '0707732837', 'CS0002', N'Nghiên cứu', N'Thần kinh', 'GkDbi7v1YaIwuSRKRpe');
EXEC THEMNHANVIEN('NV0047',N'Võ Khánh Hồng Đức', N'Nam', '1926-12-22','831053317484', N'Bắc Ninh', '0705046586', 'CS0003', N'Nghiên cứu', N'Ung thư', '5icu7lB7SGUnVgrnIu');
EXEC THEMNHANVIEN('NV0048',N'Ngô Khánh Thảo', N'Nam', '1995-07-15','669560958954', N'Bến Tre', '0795460743', 'CS0004', N'Nghiên cứu', N'Tai, mũi, họng', '7z6GDNdk7GwyZ');
EXEC THEMNHANVIEN('NV0049',N'Hứa Văn Thảo Nhiên', N'Nam', '1978-03-05','192131394187', N'Bến Tre', '0337745984', 'CS0005', N'Nghiên cứu', N'Trẻ em', 'plm9R6kpV5a7');
EXEC THEMNHANVIEN('NV0050',N'Lý Bửu Hải Ngọc', N'Nữ', '1963-11-24','081066600741', N'Cần Thơ', '0762872464', 'CS0006', N'Nghiên cứu', N'Thần kinh', 'JT8rjQarAAGpdBfsNkTP');
EXEC THEMNHANVIEN('NV0051',N'Vũ Anh Minh', N'Nữ', '1984-10-30','149142094761', N'Tây Ninh', '0363054324', 'CS0007', N'Nghiên cứu', N'Ung thư', 'K7lld7U4nj');
EXEC THEMNHANVIEN('NV0052',N'Đỗ Văn Linh Dũng', N'Nam', '1959-02-21','246664081455', N'Trà Vinh', '0397266327', 'CS0008', N'Nghiên cứu', N'Tai, mũi, họng', 'PJsto5Vt4');
EXEC THEMNHANVIEN('NV0053',N'Huỳnh Hồng Nhã', N'Nữ', '1990-10-11','486029082553', N'Trà Vinh', '0366557995', 'CS0009', N'Nghiên cứu', N'Trẻ em', 'Alg7SCNqm36');
EXEC THEMNHANVIEN('NV0054',N'Danh Ngọc Hương', N'Nam', '1982-06-25','434137157331', N'Trà Vinh', '0895427996', 'CS0010', N'Nghiên cứu', N'Thần kinh', 'aQP3HCwcDZgtbUiO');
EXEC THEMNHANVIEN('NV0055',N'Ngô Ngọc Giang', N'Nữ', '1970-09-25','139112345202', N'Bắc Ninh', '0323612344', 'CS0001', N'Nghiên cứu', N'Ung thư', 'jU1thb5vhXgLLosp');
EXEC THEMNHANVIEN('NV0056',N'Nguyễn Văn Á', N'Nam', '1950-01-12','131234531202', N'Trà Vinh', '0123650714', NULL, N'Giám đốc sở', NULL, 'jU1thb5vhXgLLosp');
EXEC THEMNHANVIEN('NV0057',N'Nguyễn Thị Bề', N'Nữ', '1971-05-23','112345531202', N'Trà Vinh', '0323651234', NULL, N'Giám đốc CSYT TT', NULL, 'jU1thb5vhXgLLosp');
EXEC THEMNHANVIEN('NV0058',N'Nguyễn Văn Sễ', N'Nam', '1972-02-10','139101512345', N'Trà Vinh', '0123450714', NULL, N'Giám đốc CSYT CTT', NULL, 'jU1thb5vhXgLLosp');
EXEC THEMNHANVIEN('NV0059',N'Nguyễn Thị Đệ', N'Nữ', '1973-07-20','123451531202', N'Trà Vinh', '0312350714', NULL, N'Giám đốc CSYT NT', NULL, 'jU1thb5vhXgLLosp');
--select * from nhanvien;

-- INSERT DATA INTO BENHNHAN
EXEC THEMBENHNHAN('BN000001','CS0002', N'Trần Việt Đào Bình','916773394945', '1954-03-11', '148', N'3 tháng 2', N'Q.1', N'Cần Thơ', N'NULL', N'NULL', N'NULL','TyHFH6hOI2Hz97BX');
EXEC THEMBENHNHAN('BN000002','CS0003', N'Hứa Trung Tường','477197069125', '1945-02-03', '421', N'Nguyễn Thị Lựu', N'Q.2', N'Tây Ninh', N'NULL', N'NULL', N'NULL','q1kFYXRdaZtHmyZwJRB');
EXEC THEMBENHNHAN('BN000003','CS0004', N'Trịnh Khánh Huyền Tâm','644198063807', '1942-06-27', '101', N'Lý Chiến Thắng', N'Q.5', N'Tây Ninh', N'Động kinh', N'Hội chứng down', N'Aspirin','YZTdeDXt');
EXEC THEMBENHNHAN('BN000004','CS0005', N'Hồ Bửu Dung','307780507980', '1984-03-25', '237', N'Nguyễn Thị Minh Khai', N'Q.1', N'Bắc Ninh', N'Hen suyễn mãn tính, Đái tháo đường', N'Ung thư phổi', N'Amoxicillin, Cephalosporin','GAyIN0Ey4');
EXEC THEMBENHNHAN('BN000005','CS0006', N'Hồ Mỹ Lan Dung','480148058972', '1970-08-06', '332', N'Đinh Công Tránh', N'Q.Gò Vấp', N'Tây Ninh', N'Ung thư phổi', N'Bệnh tim, Đái tháo đường', N'Thuốc gây tê','F3OBUHuTpJO');
EXEC THEMBENHNHAN('BN000006','CS0007', N'Ung Huỳnh Ly','625421696262', '1942-05-14', '259', N'3 tháng 2', N'Huyện Nhà Bè', N'Tây Ninh', N'Viêm phế quản mãn tính', N'U xơ cổ tử cung, Ung thư buồng trứng', N'Insulin','k5hMEiLthuCzljgV3OH4');
EXEC THEMBENHNHAN('BN000007','CS0008', N'Đặng Hà Tâm Thi','093142227246', '1958-03-11', '392', N'Nguyễn Thành Ý', N'Q.Thủ Đức', N'Cần Thơ', N'U xơ tử cung', N'Bệnh tim', N'Paracetamol','GZsMFvH9rSP');
EXEC THEMBENHNHAN('BN000008','CS0009', N'Huỳnh Khánh Hiền Lam','908519739639', '1985-07-08', '365', N'Nguyễn Trãi', N'Q.Bình Thạnh', N'Bến Tre', N'Bệnh động mạch vành _ CAD ( Thiếu máu cơ tim), Nhồi máu cơ tim', N'Bệnh máu khó đông di truyền (Hemophilie A)', N'Penicillin, Ampicillin','roWj79yQ95K3vUpffFcT');
EXEC THEMBENHNHAN('BN000009','CS0010', N'Huỳnh Bửu Bách Chi','611825513067', '1965-07-04', '312', N'Lê Thị Riêng', N'Q.8', N'TP.HCM', N'Cao huyết áp, Viêm phổi, Viêm gan', N'Bệnh động kinh', N'Streptomycin','BhZGqieQ');
EXEC THEMBENHNHAN('BN000010','CS0001', N'Trần Việt Đức Hoa','828559055899', '1934-07-16', '228', N'Nguyễn Đình Chiểu', N'Huyện Nhà Bè', N'TP.HCM', N'Đột quỵ, bệnh tim', N'Hội chứng down', N'Sulfonamide','twUOVlLmUhJSpKfFrqhY');

--select * from benhnhan;

--INSERT DATA TO HSBA
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0001', 'BN000001', TO_DATE('2017-01-12', 'yyyy-mm-dd'), 'Ung thư vú', 'NV0026', 'K00001', 'CS0001', 'Ung thư vú giai đoạn cuối');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0002', 'BN000002', TO_DATE('2018-02-05', 'yyyy-mm-dd'), 'Suy hô hấp cấp ', 'NV0027', 'K00002', 'CS0002', 'Suy hô hấp cấp không đe doạ tính mạng, Viêm phổi cộng đồng mức độ nhẹ ');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0003', 'BN000003', TO_DATE('2018-07-08', 'yyyy-mm-dd'), 'Suy thận mạn', 'NV0028', 'K00003', 'CS0003', 'Suy thận mạn giai đoạn cuối');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0004', 'BN000004', TO_DATE('2019-11-09', 'yyyy-mm-dd'), 'Bệnh động mạch vành', 'NV0029', 'K00004', 'CS0004', 'Bệnh động mạch vành, Hở van 2 lá 2/4');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0005', 'BN000005', TO_DATE('2020-05-23', 'yyyy-mm-dd'), 'Viêm xoang', 'NV0030', 'K00001', 'CS0006', 'Viêm xoang');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0006', 'BN000006', TO_DATE('2020-09-14', 'yyyy-mm-dd'), 'Sốt xuát huyết', 'NV0031', 'K00001', 'CS0007', 'Sốt xuất huyết giai đoạn 1');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0007', 'BN000007', TO_DATE('2021-01-29', 'yyyy-mm-dd'), 'Viêm tai', 'NV0032', 'K00003', 'CS0008', 'Nhiễm trùng tai');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0008', 'BN000008', TO_DATE('2022-02-16', 'yyyy-mm-dd'), 'Viêm họng', 'NV0033', 'K00004', 'CS0009', 'Viêm amidan cấp');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0009', 'BN000009', TO_DATE('2022-02-28', 'yyyy-mm-dd'), 'Viêm phổi', 'NV0034', 'K00001', 'CS0010', 'Ung thư phổi');
INSERT INTO HSBA(MAHSBA,MABN,NGAY,CHANDOAN,MABS,MAKHOA,MACSYT,KETLUAN) 
VALUES ('HSBA0010', 'BN000010', TO_DATE('2022-05-01', 'yyyy-mm-dd'), 'Đa xơ cứng', 'NV0044', 'K00004', 'CS0010', 'Đa xơ cứng');


--select * from HSBA;

--INSERT DATA TO HSBA_DV
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0001', 'DV0001',TO_DATE('2017-01-12', 'yyyy-mm-dd'), 'NV0027', 'ket qua dich vu 1');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0001', 'DV0002',TO_DATE('2017-01-12', 'yyyy-mm-dd'), 'NV0028', 'ket qua dich vu 2');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0002', 'DV0001',TO_DATE('2018-02-05', 'yyyy-mm-dd'), 'NV0026', 'ket qua dich vu 3');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0003', 'DV0003',TO_DATE('2018-07-08', 'yyyy-mm-dd'), 'NV0029', 'ket qua dich vu 5');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0004', 'DV0005',TO_DATE('2019-11-09', 'yyyy-mm-dd'), 'NV0035', 'ket qua dich vu 6');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0004', 'DV0003',TO_DATE('2019-11-09', 'yyyy-mm-dd'), 'NV0036', 'ket qua dich vu 7');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0005', 'DV0001',TO_DATE('2020-05-23', 'yyyy-mm-dd'), 'NV0028', 'ket qua dich vu 8');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0005', 'DV0004',TO_DATE('2020-05-23', 'yyyy-mm-dd'), 'NV0027', 'ket qua dich vu 9');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0006', 'DV0002',TO_DATE('2020-09-14', 'yyyy-mm-dd'), 'NV0029', 'ket qua dich vu 10');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0007', 'DV0003',TO_DATE('2021-01-29', 'yyyy-mm-dd'), 'NV0035', 'ket qua dich vu 11');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0008', 'DV0005',TO_DATE('2018-07-08', 'yyyy-mm-dd'), 'NV0029', 'ket qua dich vu 12');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0009', 'DV0002',TO_DATE('2018-07-08', 'yyyy-mm-dd'), 'NV0040', 'ket qua dich vu 13');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0009', 'DV0004',TO_DATE('2022-02-28', 'yyyy-mm-dd'), 'NV0027', 'ket qua dich vu 14');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0010', 'DV0002',TO_DATE('2022-05-01', 'yyyy-mm-dd'), 'NV0040', 'ket qua dich vu 15');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0010', 'DV0001',TO_DATE('2022-05-01', 'yyyy-mm-dd'), 'NV0041', 'ket qua dich vu 16');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0010', 'DV0004',TO_DATE('2022-05-01', 'yyyy-mm-dd'), 'NV0042', 'ket qua dich vu 17');
INSERT INTO HSBA_DV(MAHSBA,MADV,NGAY,MAKTV,KETQUA)
VALUES ('HSBA0010', 'DV0005',TO_DATE('2022-05-01', 'yyyy-mm-dd'), 'NV0043', 'ket qua dich vu 18');


--select * from HSBA_DV;

