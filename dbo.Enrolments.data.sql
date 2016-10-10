SET IDENTITY_INSERT [dbo].[Enrolments] ON
INSERT INTO [dbo].[Enrolments] ([ID], [PaymentReceived], [PaymentDue], [ChildID], [ActivityID]) VALUES (2, 1, 1, 2, 1)
INSERT INTO [dbo].[Enrolments] ([ID], [PaymentReceived], [PaymentDue], [ChildID], [ActivityID]) VALUES (3, 0, 1, 4, 2)
INSERT INTO [dbo].[Enrolments] ([ID], [PaymentReceived], [PaymentDue], [ChildID], [ActivityID]) VALUES (4, 0, 0, 3, 3)
SET IDENTITY_INSERT [dbo].[Enrolments] OFF

