USE [Building Manangement]
GO
/****** Object:  Table [dbo].[Action]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action](
	[id_action] [int] IDENTITY(1,1) NOT NULL,
	[kind_of_action] [bit] NULL,
	[action_description] [varchar](50) NULL,
	[action_date] [date] NULL,
	[action_sum] [int] NULL,
	[id_tenant] [int] NULL,
	[id_building] [int] NULL,
	[id_action_category] [int] NULL,
 CONSTRAINT [PK_budget] PRIMARY KEY CLUSTERED 
(
	[id_action] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Action_Category]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Action_Category](
	[id_action_category] [int] IDENTITY(1,1) NOT NULL,
	[action_category_description] [nchar](10) NOT NULL,
	[id_building] [int] NOT NULL,
 CONSTRAINT [PK_Action_Category] PRIMARY KEY CLUSTERED 
(
	[id_action_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[id_building] [int] IDENTITY(1,1) NOT NULL,
	[city] [varchar](50) NULL,
	[street] [varchar](20) NULL,
	[street_num] [int] NULL,
	[floors_num] [int] NULL,
	[apartments_num] [int] NULL,
	[id_tenantManager] [int] NULL,
	[month_cost] [int] NULL,
	[cash_box] [int] NULL,
	[professonal] [varchar](100) NULL,
	[tenants] [varchar](500) NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[id_building] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[id_comment] [int] IDENTITY(1,1) NOT NULL,
	[id_meeting] [int] NOT NULL,
	[id_tenant] [int] NOT NULL,
	[comment_description] [varchar](20) NOT NULL,
	[comment_date] [date] NOT NULL,
	[id_building] [int] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[id_comment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Common Space]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Common Space](
	[id_common_space] [int] IDENTITY(1,1) NOT NULL,
	[id_building] [int] NULL,
	[activity_days] [varchar](20) NULL,
	[activity_hours] [varchar](50) NULL,
	[schedule] [varchar](200) NULL,
 CONSTRAINT [PK_Common Space] PRIMARY KEY CLUSTERED 
(
	[id_common_space] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[experience]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[experience](
	[id_experience] [int] IDENTITY(1,1) NOT NULL,
	[event_date] [datetime] NOT NULL,
	[title] [nvarchar](50) NOT NULL,
	[event_building] [int] NOT NULL,
 CONSTRAINT [PK__experien__9B828C748BA1CE39] PRIMARY KEY CLUSTERED 
(
	[id_experience] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting](
	[id_meeting] [int] IDENTITY(1,1) NOT NULL,
	[meeting_subject] [varchar](20) NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[meeting_description] [text] NOT NULL,
	[id_building] [int] NOT NULL,
 CONSTRAINT [PK_Meeting] PRIMARY KEY CLUSTERED 
(
	[id_meeting] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting_vote]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting_vote](
	[id_meeting_vote] [int] IDENTITY(1,1) NOT NULL,
	[id_meeting] [int] NOT NULL,
	[id_building] [int] NOT NULL,
	[vote_description] [varchar](1000) NULL,
 CONSTRAINT [PK_Meeting_vote] PRIMARY KEY CLUSTERED 
(
	[id_meeting_vote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id_payment] [int] IDENTITY(1,1) NOT NULL,
	[id_tenant] [int] NOT NULL,
	[payment_date] [date] NOT NULL,
	[payment_month] [int] NOT NULL,
	[done] [bit] NOT NULL,
	[payment_sum] [int] NULL,
	[id_building] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id_payment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professonal]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professonal](
	[id_professonal] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](10) NULL,
	[last_name] [varchar](10) NULL,
	[tz] [varchar](9) NULL,
	[phone] [varchar](10) NULL,
	[email] [varchar](20) NULL,
	[buildings] [varchar](50) NULL,
	[professonal_category] [int] NULL,
	[hour_cost] [int] NULL,
 CONSTRAINT [PK_Professonal] PRIMARY KEY CLUSTERED 
(
	[id_professonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professonal_Category]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professonal_Category](
	[id_professonal_category] [int] IDENTITY(1,1) NOT NULL,
	[professonal_category_description] [varchar](50) NULL,
	[id_building] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id_professonal_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[id_request] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[tz] [varchar](9) NULL,
	[phone] [varchar](10) NULL,
	[email] [varchar](20) NULL,
	[city] [varchar](20) NULL,
	[street] [varchar](20) NULL,
	[street_num] [int] NULL,
	[apartment_num] [int] NULL,
	[floor_num] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_request] PRIMARY KEY CLUSTERED 
(
	[id_request] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id_status] [int] IDENTITY(1,1) NOT NULL,
	[status_description] [varchar](20) NOT NULL,
 CONSTRAINT [PK_permission] PRIMARY KEY CLUSTERED 
(
	[id_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[id_tenant] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](20) NULL,
	[last_name] [varchar](20) NULL,
	[tz] [varchar](9) NULL,
	[phone] [varchar](10) NULL,
	[email] [varchar](40) NULL,
	[id_building] [int] NULL,
	[apartment_num] [int] NULL,
	[floor_num] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[id_tenant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenantManager_Messeage]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantManager_Messeage](
	[id_tenantManager_messeage] [int] IDENTITY(1,1) NOT NULL,
	[id_tenantManager] [int] NOT NULL,
	[id_building] [int] NOT NULL,
	[description_tenantManager_messeage] [varchar](50) NOT NULL,
	[tenantManager_messeage_date] [date] NOT NULL,
 CONSTRAINT [PK_TenantManager_messeage] PRIMARY KEY CLUSTERED 
(
	[id_tenantManager_messeage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteer]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteer](
	[id_volunteer] [int] IDENTITY(1,1) NOT NULL,
	[id_building] [int] NULL,
	[id_tenant] [int] NULL,
	[id_volunteering] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[done] [bit] NULL,
 CONSTRAINT [PK_Volunteers] PRIMARY KEY CLUSTERED 
(
	[id_volunteer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteering]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteering](
	[id_volunteering] [int] IDENTITY(1,1) NOT NULL,
	[id_building] [int] NOT NULL,
	[id_volunteering_category] [int] NULL,
	[volunteering_description] [varchar](50) NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[requred] [bit] NOT NULL,
	[min_time] [int] NULL,
	[max_time] [int] NULL,
	[status] [int] NULL,
 CONSTRAINT [PK_Valentear] PRIMARY KEY CLUSTERED 
(
	[id_volunteering] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteering_Category]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteering_Category](
	[id_volunteering_category] [int] IDENTITY(1,1) NOT NULL,
	[description_volunteering_category] [varchar](50) NOT NULL,
	[id_bulding] [int] NOT NULL,
 CONSTRAINT [PK_Volunteering_category] PRIMARY KEY CLUSTERED 
(
	[id_volunteering_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 30/03/2021 00:11:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[id_vote] [int] IDENTITY(1,1) NOT NULL,
	[id_meeting] [int] NOT NULL,
	[vote_subject] [varchar](50) NULL,
	[vote_description] [text] NULL,
	[tenants_vote] [varchar](200) NULL,
	[id_building] [int] NOT NULL,
	[id_tenant] [int] NULL,
	[id_vote_meeting] [int] NULL,
 CONSTRAINT [PK_Vote] PRIMARY KEY CLUSTERED 
(
	[id_vote] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_Action_Action_Category] FOREIGN KEY([id_action_category])
REFERENCES [dbo].[Action_Category] ([id_action_category])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_Action_Action_Category]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_budget_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_budget_Building]
GO
ALTER TABLE [dbo].[Action]  WITH CHECK ADD  CONSTRAINT [FK_budget_Tenant] FOREIGN KEY([id_tenant])
REFERENCES [dbo].[Tenant] ([id_tenant])
GO
ALTER TABLE [dbo].[Action] CHECK CONSTRAINT [FK_budget_Tenant]
GO
ALTER TABLE [dbo].[Action_Category]  WITH CHECK ADD  CONSTRAINT [FK_Action_Category_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Action_Category] CHECK CONSTRAINT [FK_Action_Category_Building]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Building]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Meeting] FOREIGN KEY([id_meeting])
REFERENCES [dbo].[Meeting] ([id_meeting])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Meeting]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Resident] FOREIGN KEY([id_tenant])
REFERENCES [dbo].[Tenant] ([id_tenant])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Resident]
GO
ALTER TABLE [dbo].[Common Space]  WITH CHECK ADD  CONSTRAINT [FK_Common Space_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Common Space] CHECK CONSTRAINT [FK_Common Space_Building]
GO
ALTER TABLE [dbo].[Meeting]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Meeting] CHECK CONSTRAINT [FK_Meeting_Building]
GO
ALTER TABLE [dbo].[Meeting_vote]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_vote_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Meeting_vote] CHECK CONSTRAINT [FK_Meeting_vote_Building]
GO
ALTER TABLE [dbo].[Meeting_vote]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_vote_Meeting] FOREIGN KEY([id_meeting])
REFERENCES [dbo].[Meeting] ([id_meeting])
GO
ALTER TABLE [dbo].[Meeting_vote] CHECK CONSTRAINT [FK_Meeting_vote_Meeting]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Resident] FOREIGN KEY([id_tenant])
REFERENCES [dbo].[Tenant] ([id_tenant])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Resident]
GO
ALTER TABLE [dbo].[Professonal]  WITH CHECK ADD  CONSTRAINT [FK_Professonal_Category] FOREIGN KEY([professonal_category])
REFERENCES [dbo].[Professonal_Category] ([id_professonal_category])
GO
ALTER TABLE [dbo].[Professonal] CHECK CONSTRAINT [FK_Professonal_Category]
GO
ALTER TABLE [dbo].[Professonal_Category]  WITH CHECK ADD  CONSTRAINT [FK_Professonal_category_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Professonal_Category] CHECK CONSTRAINT [FK_Professonal_category_Building]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Status] FOREIGN KEY([status])
REFERENCES [dbo].[Status] ([id_status])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Status]
GO
ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [FK__Tenant__id_build__5165187F] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [FK__Tenant__id_build__5165187F]
GO
ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [FK_Resident_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [FK_Resident_Building]
GO
ALTER TABLE [dbo].[Tenant]  WITH CHECK ADD  CONSTRAINT [FK_Resident_Status] FOREIGN KEY([status])
REFERENCES [dbo].[Status] ([id_status])
GO
ALTER TABLE [dbo].[Tenant] CHECK CONSTRAINT [FK_Resident_Status]
GO
ALTER TABLE [dbo].[TenantManager_Messeage]  WITH CHECK ADD  CONSTRAINT [FK_TenantManager_messeage_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[TenantManager_Messeage] CHECK CONSTRAINT [FK_TenantManager_messeage_Building]
GO
ALTER TABLE [dbo].[TenantManager_Messeage]  WITH CHECK ADD  CONSTRAINT [FK_TenantManager_messeage_Tenant] FOREIGN KEY([id_tenantManager])
REFERENCES [dbo].[Tenant] ([id_tenant])
GO
ALTER TABLE [dbo].[TenantManager_Messeage] CHECK CONSTRAINT [FK_TenantManager_messeage_Tenant]
GO
ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteer_Tenant] FOREIGN KEY([id_tenant])
REFERENCES [dbo].[Tenant] ([id_tenant])
GO
ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteer_Tenant]
GO
ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteer_Tenant1] FOREIGN KEY([id_tenant])
REFERENCES [dbo].[Tenant] ([id_tenant])
GO
ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteer_Tenant1]
GO
ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteer_Tenant2] FOREIGN KEY([id_tenant])
REFERENCES [dbo].[Tenant] ([id_tenant])
GO
ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteer_Tenant2]
GO
ALTER TABLE [dbo].[Volunteer]  WITH CHECK ADD  CONSTRAINT [FK_Volunteers_Volunteering] FOREIGN KEY([id_volunteering])
REFERENCES [dbo].[Volunteering] ([id_volunteering])
GO
ALTER TABLE [dbo].[Volunteer] CHECK CONSTRAINT [FK_Volunteers_Volunteering]
GO
ALTER TABLE [dbo].[Volunteering]  WITH CHECK ADD  CONSTRAINT [FK_Volunteering_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Volunteering] CHECK CONSTRAINT [FK_Volunteering_Building]
GO
ALTER TABLE [dbo].[Volunteering]  WITH CHECK ADD  CONSTRAINT [FK_Volunteering_Volunteering_category] FOREIGN KEY([id_volunteering_category])
REFERENCES [dbo].[Volunteering_Category] ([id_volunteering_category])
GO
ALTER TABLE [dbo].[Volunteering] CHECK CONSTRAINT [FK_Volunteering_Volunteering_category]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Building] FOREIGN KEY([id_building])
REFERENCES [dbo].[Building] ([id_building])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Building]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Meeting] FOREIGN KEY([id_meeting])
REFERENCES [dbo].[Meeting] ([id_meeting])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Meeting]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_Meeting_vote] FOREIGN KEY([id_vote_meeting])
REFERENCES [dbo].[Meeting_vote] ([id_meeting_vote])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_Meeting_vote]
GO
