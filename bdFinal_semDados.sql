USE [SiltesSaude]
GO
ALTER TABLE [dbo].[ZaragatoaOnofaringe] DROP CONSTRAINT [FK_ZaragatoaOnofaringe_Paciente]
GO
ALTER TABLE [dbo].[ZaragatoaOnofaringe] DROP CONSTRAINT [FK_ZaragatoaOnofaringe_Atitude]
GO
ALTER TABLE [dbo].[VariasAtitudes] DROP CONSTRAINT [FK_VariasAtitudes_Paciente]
GO
ALTER TABLE [dbo].[VariasAtitudes] DROP CONSTRAINT [FK_VariasAtitudes_Atitude]
GO
ALTER TABLE [dbo].[Vacinacao] DROP CONSTRAINT [FK_Vacinacao_Paciente]
GO
ALTER TABLE [dbo].[Tricotomia] DROP CONSTRAINT [FK_Tricotomia_Paciente]
GO
ALTER TABLE [dbo].[Tricotomia] DROP CONSTRAINT [FK_Tricotomia_Atitude]
GO
ALTER TABLE [dbo].[TratamentoPaciente] DROP CONSTRAINT [FK_TratamentoPaciente_Ulcera]
GO
ALTER TABLE [dbo].[TratamentoPaciente] DROP CONSTRAINT [FK_TratamentoPaciente_Tratamento]
GO
ALTER TABLE [dbo].[TratamentoPaciente] DROP CONSTRAINT [FK_TratamentoPaciente_Queimadura]
GO
ALTER TABLE [dbo].[TratamentoPaciente] DROP CONSTRAINT [FK_TratamentoPaciente_Paciente]
GO
ALTER TABLE [dbo].[TratamentoExcisoes] DROP CONSTRAINT [FK_TratamentoExcisoes_Tratamento]
GO
ALTER TABLE [dbo].[TratamentoExcisoes] DROP CONSTRAINT [FK_TratamentoExcisoes_Paciente]
GO
ALTER TABLE [dbo].[TesteCombur] DROP CONSTRAINT [FK_TesteCombur_Paciente]
GO
ALTER TABLE [dbo].[TesteCombur] DROP CONSTRAINT [FK_TesteCombur_Atitude]
GO
ALTER TABLE [dbo].[TesteAcuidadeVisual] DROP CONSTRAINT [FK_TesteAcuidadeVisual_Paciente]
GO
ALTER TABLE [dbo].[TesteAcuidadeVisual] DROP CONSTRAINT [FK_TesteAcuidadeVisual_Atitude]
GO
ALTER TABLE [dbo].[Suturas] DROP CONSTRAINT [FK_Suturas_Paciente]
GO
ALTER TABLE [dbo].[Suturas] DROP CONSTRAINT [FK_Suturas_Atitude]
GO
ALTER TABLE [dbo].[ProdutoStock] DROP CONSTRAINT [FK_ProdutoStock_Fornecedor]
GO
ALTER TABLE [dbo].[Pressoterapia] DROP CONSTRAINT [FK_Pressoterapia_Paciente]
GO
ALTER TABLE [dbo].[Pressoterapia] DROP CONSTRAINT [FK_Pressoterapia_Atitude]
GO
ALTER TABLE [dbo].[Paciente] DROP CONSTRAINT [FK_Paciente_Profissao]
GO
ALTER TABLE [dbo].[Paciente] DROP CONSTRAINT [FK_Paciente_Enfermeiro]
GO
ALTER TABLE [dbo].[MonitorizacaoECG] DROP CONSTRAINT [FK_MonitorizacaoECG_Paciente]
GO
ALTER TABLE [dbo].[MonitorizacaoECG] DROP CONSTRAINT [FK_MonitorizacaoECG_Atitude]
GO
ALTER TABLE [dbo].[Medicacao] DROP CONSTRAINT [FK_Medicacao_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorVacinacao] DROP CONSTRAINT [FK_LocalizacaoDorVacinacao_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorEspirometria] DROP CONSTRAINT [FK_LocalizacaoDorEspirometria_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorDopplerFetal] DROP CONSTRAINT [FK_LocalizacaoDorDopplerFetal_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorDopplerArterialVenoso] DROP CONSTRAINT [FK_LocalizacaoDorDopplerArterialVenoso_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorConsulta] DROP CONSTRAINT [FK_LocalizacaoDorConsulta_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDor] DROP CONSTRAINT [FK_LocalizacaoDor_TratamentoMaosPes]
GO
ALTER TABLE [dbo].[LocalizacaoDor] DROP CONSTRAINT [FK_LocalizacaoDor_Paciente]
GO
ALTER TABLE [dbo].[LinhaEncomenda] DROP CONSTRAINT [FK_LinhaEncomenda_ProdutoStock]
GO
ALTER TABLE [dbo].[LinhaEncomenda] DROP CONSTRAINT [FK_LinhaEncomenda_Encomenda]
GO
ALTER TABLE [dbo].[LavagemVesical] DROP CONSTRAINT [FK_LavagemVesical_Paciente]
GO
ALTER TABLE [dbo].[LavagemVesical] DROP CONSTRAINT [FK_LavagemVesical_Atitude]
GO
ALTER TABLE [dbo].[LavagemOcular] DROP CONSTRAINT [FK_LavagemOcular_Paciente]
GO
ALTER TABLE [dbo].[LavagemOcular] DROP CONSTRAINT [FK_LavagemOcular_Atitude]
GO
ALTER TABLE [dbo].[LavagemAuricular] DROP CONSTRAINT [FK_LavagemAuricular_Paciente]
GO
ALTER TABLE [dbo].[LavagemAuricular] DROP CONSTRAINT [FK_LavagemAuricular_Atitude]
GO
ALTER TABLE [dbo].[Inalacoes] DROP CONSTRAINT [FK_Inalacoes_Paciente]
GO
ALTER TABLE [dbo].[Inalacoes] DROP CONSTRAINT [FK_Inalacoes_Atitude]
GO
ALTER TABLE [dbo].[ImplanteContracetivo] DROP CONSTRAINT [FK_ImplanteContracetivo_Paciente]
GO
ALTER TABLE [dbo].[ImplanteContracetivo] DROP CONSTRAINT [FK_ImplanteContracetivo_Atitude]
GO
ALTER TABLE [dbo].[Flebografia] DROP CONSTRAINT [FK_Flebografia_Paciente]
GO
ALTER TABLE [dbo].[Flebografia] DROP CONSTRAINT [FK_Flebografia_Atitude]
GO
ALTER TABLE [dbo].[Exame] DROP CONSTRAINT [FK_Exame_TipoExame]
GO
ALTER TABLE [dbo].[Exame] DROP CONSTRAINT [FK_Exame_Paciente]
GO
ALTER TABLE [dbo].[Espirometria] DROP CONSTRAINT [FK_Espirometria_Paciente]
GO
ALTER TABLE [dbo].[ENG] DROP CONSTRAINT [FK_ENG_Paciente]
GO
ALTER TABLE [dbo].[ENG] DROP CONSTRAINT [FK_ENG_Atitude]
GO
ALTER TABLE [dbo].[Encomenda] DROP CONSTRAINT [FK_Encomenda_Fornecedor]
GO
ALTER TABLE [dbo].[DrenagemLocas] DROP CONSTRAINT [FK_DrenagemLocas_Paciente]
GO
ALTER TABLE [dbo].[DrenagemLocas] DROP CONSTRAINT [FK_DrenagemLocas_Atitude]
GO
ALTER TABLE [dbo].[DopletFetal] DROP CONSTRAINT [FK_DopletFetal_Paciente]
GO
ALTER TABLE [dbo].[DoencaPaciente] DROP CONSTRAINT [FK_DoencaPaciente_Paciente]
GO
ALTER TABLE [dbo].[DoencaPaciente] DROP CONSTRAINT [FK_DoencaPaciente_Doenca]
GO
ALTER TABLE [dbo].[Despesa] DROP CONSTRAINT [FK_Despesa_TipoDespesa]
GO
ALTER TABLE [dbo].[Despesa] DROP CONSTRAINT [FK_Despesa_Encomenda]
GO
ALTER TABLE [dbo].[Desbridamento] DROP CONSTRAINT [FK_Desbridamento_Paciente]
GO
ALTER TABLE [dbo].[Desbridamento] DROP CONSTRAINT [FK_Desbridamento_Atitude]
GO
ALTER TABLE [dbo].[Crioterapia] DROP CONSTRAINT [FK_Crioterapia_Paciente]
GO
ALTER TABLE [dbo].[Crioterapia] DROP CONSTRAINT [FK_Crioterapia_Atitude]
GO
ALTER TABLE [dbo].[ConsultaProdutoStock] DROP CONSTRAINT [FK_ConsultaProdutoStock_ProdutoStock]
GO
ALTER TABLE [dbo].[Consulta] DROP CONSTRAINT [FK_Consulta_Paciente]
GO
ALTER TABLE [dbo].[Consulta] DROP CONSTRAINT [FK_Consulta_Enfermeiro]
GO
ALTER TABLE [dbo].[Colpocitologia] DROP CONSTRAINT [FK_Colpocitologia_Paciente]
GO
ALTER TABLE [dbo].[Colpocitologia] DROP CONSTRAINT [FK_Colpocitologia_Atitude]
GO
ALTER TABLE [dbo].[ColocacaoDIU] DROP CONSTRAINT [FK_ColocacaoDIU_Paciente]
GO
ALTER TABLE [dbo].[ColocacaoDIU] DROP CONSTRAINT [FK_ColocacaoDIU_Atitude]
GO
ALTER TABLE [dbo].[ColheitaUrina] DROP CONSTRAINT [FK_ColheitaUrina_Paciente]
GO
ALTER TABLE [dbo].[ColheitaUrina] DROP CONSTRAINT [FK_ColheitaUrina_Atitude]
GO
ALTER TABLE [dbo].[ColheitadeSanguePrecoce] DROP CONSTRAINT [FK_ColheitadeSanguePrecoce_Paciente]
GO
ALTER TABLE [dbo].[ColheitadeSanguePrecoce] DROP CONSTRAINT [FK_ColheitadeSanguePrecoce_Atitude]
GO
ALTER TABLE [dbo].[CirurgiaPaciente] DROP CONSTRAINT [FK_CirurgiaPaciente_Paciente]
GO
ALTER TABLE [dbo].[CirurgiaPaciente] DROP CONSTRAINT [FK_CirurgiaPaciente_Cirurgia]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe] DROP CONSTRAINT [FK_AvaliacaoObjetivoBebe_Parto]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe] DROP CONSTRAINT [FK_AvaliacaoObjetivoBebe_Paciente]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe] DROP CONSTRAINT [FK_AvaliacaoObjetivoBebe_Aleitamento]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivo] DROP CONSTRAINT [FK_AvaliacaoObjetivo_Paciente]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivo] DROP CONSTRAINT [FK_AvaliacaoObjetivo_MetodoContracetivo]
GO
ALTER TABLE [dbo].[AspiracaoSecrecao] DROP CONSTRAINT [FK_AspiracaoSecrecao_Paciente]
GO
ALTER TABLE [dbo].[AspiracaoSecrecao] DROP CONSTRAINT [FK_AspiracaoSecrecao_Atitude]
GO
ALTER TABLE [dbo].[analisesLaboratoriaisPaciente] DROP CONSTRAINT [FK_analisesLaboratoriaisPaciente_Paciente]
GO
ALTER TABLE [dbo].[analisesLaboratoriaisPaciente] DROP CONSTRAINT [FK_analisesLaboratoriaisPaciente_Analises]
GO
ALTER TABLE [dbo].[Algariacao] DROP CONSTRAINT [FK_Algariacao_Paciente]
GO
ALTER TABLE [dbo].[Algariacao] DROP CONSTRAINT [FK_Algariacao_Atitude]
GO
ALTER TABLE [dbo].[AlergiaPaciente] DROP CONSTRAINT [FK_AlergiaPaciente_Paciente]
GO
ALTER TABLE [dbo].[AlergiaPaciente] DROP CONSTRAINT [FK_AlergiaPaciente_Alergia]
GO
ALTER TABLE [dbo].[AgendamentoConsulta] DROP CONSTRAINT [FK_AgendamentoConsulta_Paciente]
GO
ALTER TABLE [dbo].[AgendamentoConsulta] DROP CONSTRAINT [FK_AgendamentoConsulta_Enfermeiro]
GO
ALTER TABLE [dbo].[AdministrarMedicacao] DROP CONSTRAINT [FK_AdministrarMedicacao_Paciente]
GO
ALTER TABLE [dbo].[AdministrarMedicacao] DROP CONSTRAINT [FK_AdministrarMedicacao_Atitude]
GO
ALTER TABLE [dbo].[Enfermeiro] DROP CONSTRAINT [DF__Enfermeir__passw__2BFE89A6]
GO
ALTER TABLE [dbo].[Enfermeiro] DROP CONSTRAINT [DF__Enfermeir__permi__2B0A656D]
GO
ALTER TABLE [dbo].[Encomenda] DROP CONSTRAINT [DF__Encomenda__pago__54CB950F]
GO
ALTER TABLE [dbo].[AgendamentoConsulta] DROP CONSTRAINT [DF__Agendamen__Consu__2A164134]
GO
/****** Object:  Table [dbo].[ZaragatoaOnofaringe]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZaragatoaOnofaringe]') AND type in (N'U'))
DROP TABLE [dbo].[ZaragatoaOnofaringe]
GO
/****** Object:  Table [dbo].[VariasAtitudes]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VariasAtitudes]') AND type in (N'U'))
DROP TABLE [dbo].[VariasAtitudes]
GO
/****** Object:  Table [dbo].[Vacinacao]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vacinacao]') AND type in (N'U'))
DROP TABLE [dbo].[Vacinacao]
GO
/****** Object:  Table [dbo].[Tricotomia]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tricotomia]') AND type in (N'U'))
DROP TABLE [dbo].[Tricotomia]
GO
/****** Object:  Table [dbo].[TratamentoPaciente]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TratamentoPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[TratamentoPaciente]
GO
/****** Object:  Table [dbo].[TratamentoMaosPes]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TratamentoMaosPes]') AND type in (N'U'))
DROP TABLE [dbo].[TratamentoMaosPes]
GO
/****** Object:  Table [dbo].[TratamentoExcisoes]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TratamentoExcisoes]') AND type in (N'U'))
DROP TABLE [dbo].[TratamentoExcisoes]
GO
/****** Object:  Table [dbo].[Tratamento]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tratamento]') AND type in (N'U'))
DROP TABLE [dbo].[Tratamento]
GO
/****** Object:  Table [dbo].[tipoUlcera]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoUlcera]') AND type in (N'U'))
DROP TABLE [dbo].[tipoUlcera]
GO
/****** Object:  Table [dbo].[tipoQueimadura]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoQueimadura]') AND type in (N'U'))
DROP TABLE [dbo].[tipoQueimadura]
GO
/****** Object:  Table [dbo].[tipoExame]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoExame]') AND type in (N'U'))
DROP TABLE [dbo].[tipoExame]
GO
/****** Object:  Table [dbo].[tipoDespesa]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoDespesa]') AND type in (N'U'))
DROP TABLE [dbo].[tipoDespesa]
GO
/****** Object:  Table [dbo].[TesteCombur]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TesteCombur]') AND type in (N'U'))
DROP TABLE [dbo].[TesteCombur]
GO
/****** Object:  Table [dbo].[TesteAcuidadeVisual]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TesteAcuidadeVisual]') AND type in (N'U'))
DROP TABLE [dbo].[TesteAcuidadeVisual]
GO
/****** Object:  Table [dbo].[Suturas]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suturas]') AND type in (N'U'))
DROP TABLE [dbo].[Suturas]
GO
/****** Object:  Table [dbo].[Profissao]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profissao]') AND type in (N'U'))
DROP TABLE [dbo].[Profissao]
GO
/****** Object:  Table [dbo].[ProdutoStock]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProdutoStock]') AND type in (N'U'))
DROP TABLE [dbo].[ProdutoStock]
GO
/****** Object:  Table [dbo].[Pressoterapia]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pressoterapia]') AND type in (N'U'))
DROP TABLE [dbo].[Pressoterapia]
GO
/****** Object:  Table [dbo].[Parto]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parto]') AND type in (N'U'))
DROP TABLE [dbo].[Parto]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paciente]') AND type in (N'U'))
DROP TABLE [dbo].[Paciente]
GO
/****** Object:  Table [dbo].[MonitorizacaoECG]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonitorizacaoECG]') AND type in (N'U'))
DROP TABLE [dbo].[MonitorizacaoECG]
GO
/****** Object:  Table [dbo].[MetodoContracetivo]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MetodoContracetivo]') AND type in (N'U'))
DROP TABLE [dbo].[MetodoContracetivo]
GO
/****** Object:  Table [dbo].[Medicacao]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicacao]') AND type in (N'U'))
DROP TABLE [dbo].[Medicacao]
GO
/****** Object:  Table [dbo].[LocalizacaoDorVacinacao]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorVacinacao]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorVacinacao]
GO
/****** Object:  Table [dbo].[LocalizacaoDorEspirometria]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorEspirometria]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorEspirometria]
GO
/****** Object:  Table [dbo].[LocalizacaoDorDopplerFetal]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorDopplerFetal]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorDopplerFetal]
GO
/****** Object:  Table [dbo].[LocalizacaoDorDopplerArterialVenoso]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorDopplerArterialVenoso]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorDopplerArterialVenoso]
GO
/****** Object:  Table [dbo].[LocalizacaoDorConsulta]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorConsulta]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorConsulta]
GO
/****** Object:  Table [dbo].[LocalizacaoDor]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDor]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDor]
GO
/****** Object:  Table [dbo].[LinhaEncomenda]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinhaEncomenda]') AND type in (N'U'))
DROP TABLE [dbo].[LinhaEncomenda]
GO
/****** Object:  Table [dbo].[LavagemVesical]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LavagemVesical]') AND type in (N'U'))
DROP TABLE [dbo].[LavagemVesical]
GO
/****** Object:  Table [dbo].[LavagemOcular]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LavagemOcular]') AND type in (N'U'))
DROP TABLE [dbo].[LavagemOcular]
GO
/****** Object:  Table [dbo].[LavagemAuricular]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LavagemAuricular]') AND type in (N'U'))
DROP TABLE [dbo].[LavagemAuricular]
GO
/****** Object:  Table [dbo].[Inalacoes]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inalacoes]') AND type in (N'U'))
DROP TABLE [dbo].[Inalacoes]
GO
/****** Object:  Table [dbo].[ImplanteContracetivo]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImplanteContracetivo]') AND type in (N'U'))
DROP TABLE [dbo].[ImplanteContracetivo]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fornecedor]') AND type in (N'U'))
DROP TABLE [dbo].[Fornecedor]
GO
/****** Object:  Table [dbo].[Flebografia]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Flebografia]') AND type in (N'U'))
DROP TABLE [dbo].[Flebografia]
GO
/****** Object:  Table [dbo].[Exame]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exame]') AND type in (N'U'))
DROP TABLE [dbo].[Exame]
GO
/****** Object:  Table [dbo].[Espirometria]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Espirometria]') AND type in (N'U'))
DROP TABLE [dbo].[Espirometria]
GO
/****** Object:  Table [dbo].[ENG]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ENG]') AND type in (N'U'))
DROP TABLE [dbo].[ENG]
GO
/****** Object:  Table [dbo].[Enfermeiro]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enfermeiro]') AND type in (N'U'))
DROP TABLE [dbo].[Enfermeiro]
GO
/****** Object:  Table [dbo].[Encomenda]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Encomenda]') AND type in (N'U'))
DROP TABLE [dbo].[Encomenda]
GO
/****** Object:  Table [dbo].[DrenagemLocas]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DrenagemLocas]') AND type in (N'U'))
DROP TABLE [dbo].[DrenagemLocas]
GO
/****** Object:  Table [dbo].[DopletFetal]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DopletFetal]') AND type in (N'U'))
DROP TABLE [dbo].[DopletFetal]
GO
/****** Object:  Table [dbo].[DoencaPaciente]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DoencaPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[DoencaPaciente]
GO
/****** Object:  Table [dbo].[Doenca]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Doenca]') AND type in (N'U'))
DROP TABLE [dbo].[Doenca]
GO
/****** Object:  Table [dbo].[Despesa]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Despesa]') AND type in (N'U'))
DROP TABLE [dbo].[Despesa]
GO
/****** Object:  Table [dbo].[Desbridamento]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Desbridamento]') AND type in (N'U'))
DROP TABLE [dbo].[Desbridamento]
GO
/****** Object:  Table [dbo].[Crioterapia]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Crioterapia]') AND type in (N'U'))
DROP TABLE [dbo].[Crioterapia]
GO
/****** Object:  Table [dbo].[ConsultaProdutoStock]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConsultaProdutoStock]') AND type in (N'U'))
DROP TABLE [dbo].[ConsultaProdutoStock]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consulta]') AND type in (N'U'))
DROP TABLE [dbo].[Consulta]
GO
/****** Object:  Table [dbo].[Colpocitologia]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Colpocitologia]') AND type in (N'U'))
DROP TABLE [dbo].[Colpocitologia]
GO
/****** Object:  Table [dbo].[ColocacaoDIU]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColocacaoDIU]') AND type in (N'U'))
DROP TABLE [dbo].[ColocacaoDIU]
GO
/****** Object:  Table [dbo].[ColheitaUrina]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColheitaUrina]') AND type in (N'U'))
DROP TABLE [dbo].[ColheitaUrina]
GO
/****** Object:  Table [dbo].[ColheitadeSanguePrecoce]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColheitadeSanguePrecoce]') AND type in (N'U'))
DROP TABLE [dbo].[ColheitadeSanguePrecoce]
GO
/****** Object:  Table [dbo].[CirurgiaPaciente]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CirurgiaPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[CirurgiaPaciente]
GO
/****** Object:  Table [dbo].[Cirurgia]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cirurgia]') AND type in (N'U'))
DROP TABLE [dbo].[Cirurgia]
GO
/****** Object:  Table [dbo].[Cateterismo]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cateterismo]') AND type in (N'U'))
DROP TABLE [dbo].[Cateterismo]
GO
/****** Object:  Table [dbo].[AvaliacaoObjetivoBebe]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AvaliacaoObjetivoBebe]') AND type in (N'U'))
DROP TABLE [dbo].[AvaliacaoObjetivoBebe]
GO
/****** Object:  Table [dbo].[AvaliacaoObjetivo]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AvaliacaoObjetivo]') AND type in (N'U'))
DROP TABLE [dbo].[AvaliacaoObjetivo]
GO
/****** Object:  Table [dbo].[Atitude]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Atitude]') AND type in (N'U'))
DROP TABLE [dbo].[Atitude]
GO
/****** Object:  Table [dbo].[AspiracaoSecrecao]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspiracaoSecrecao]') AND type in (N'U'))
DROP TABLE [dbo].[AspiracaoSecrecao]
GO
/****** Object:  Table [dbo].[analisesLaboratoriaisPaciente]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[analisesLaboratoriaisPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[analisesLaboratoriaisPaciente]
GO
/****** Object:  Table [dbo].[analisesLaboratoriais]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[analisesLaboratoriais]') AND type in (N'U'))
DROP TABLE [dbo].[analisesLaboratoriais]
GO
/****** Object:  Table [dbo].[Algariacao]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Algariacao]') AND type in (N'U'))
DROP TABLE [dbo].[Algariacao]
GO
/****** Object:  Table [dbo].[AlergiaPaciente]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlergiaPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[AlergiaPaciente]
GO
/****** Object:  Table [dbo].[Alergia]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alergia]') AND type in (N'U'))
DROP TABLE [dbo].[Alergia]
GO
/****** Object:  Table [dbo].[Aleitamento]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Aleitamento]') AND type in (N'U'))
DROP TABLE [dbo].[Aleitamento]
GO
/****** Object:  Table [dbo].[AgendamentoConsulta]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendamentoConsulta]') AND type in (N'U'))
DROP TABLE [dbo].[AgendamentoConsulta]
GO
/****** Object:  Table [dbo].[AdministrarMedicacao]    Script Date: 02/07/2020 17:41:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdministrarMedicacao]') AND type in (N'U'))
DROP TABLE [dbo].[AdministrarMedicacao]
GO
/****** Object:  Table [dbo].[AdministrarMedicacao]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdministrarMedicacao](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[PO] [nvarchar](50) NULL,
	[retal] [nvarchar](50) NULL,
	[intradermica] [nvarchar](50) NULL,
	[intramuscular] [nvarchar](50) NULL,
	[endovenosa] [nvarchar](50) NULL,
	[subcutanea] [nvarchar](50) NULL,
	[topicoViaCutanea] [nvarchar](50) NULL,
	[topicoEfeitoLocal] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_AdministrarMedicacao] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AgendamentoConsulta]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgendamentoConsulta](
	[IdMarcacao] [int] IDENTITY(1,1) NOT NULL,
	[horaProximaConsulta] [nvarchar](max) NOT NULL,
	[dataProximaConsulta] [date] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[IdEnfermeiro] [int] NOT NULL,
	[ConsultaRealizada] [bit] NOT NULL,
 CONSTRAINT [PK_AgendamentoConsulta] PRIMARY KEY CLUSTERED 
(
	[IdMarcacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aleitamento]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aleitamento](
	[IdAleitamento] [int] IDENTITY(1,1) NOT NULL,
	[tipoAleitamento] [nvarchar](50) NOT NULL,
	[Observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Aleitamento] PRIMARY KEY CLUSTERED 
(
	[IdAleitamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alergia]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alergia](
	[IdAlergia] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Sintomas] [nvarchar](max) NULL,
 CONSTRAINT [PK_Alergia] PRIMARY KEY CLUSTERED 
(
	[IdAlergia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlergiaPaciente]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlergiaPaciente](
	[IdAlergia] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_AlergiaPaciente] PRIMARY KEY CLUSTERED 
(
	[IdAlergia] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Algariacao]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Algariacao](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[silastic] [int] NULL,
	[folley] [nvarchar](30) NULL,
	[tresVias] [nvarchar](30) NULL,
	[dataProximaRealgariacao] [date] NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Algariacao] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[analisesLaboratoriais]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[analisesLaboratoriais](
	[IdAnalisesLaboratoriais] [int] IDENTITY(1,1) NOT NULL,
	[NomeAnalise] [nvarchar](100) NOT NULL,
	[Observacoes] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAnalisesLaboratoriais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[analisesLaboratoriaisPaciente]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[analisesLaboratoriaisPaciente](
	[IdAnalisesLaboratoriais] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[resultados] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_analisesLaboratoriaisPaciente] PRIMARY KEY CLUSTERED 
(
	[IdAnalisesLaboratoriais] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspiracaoSecrecao]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspiracaoSecrecao](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[aspiracao] [nvarchar](500) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atitude]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atitude](
	[IdAtitude] [int] IDENTITY(1,1) NOT NULL,
	[nomeAtitude] [nvarchar](200) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvaliacaoObjetivo]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvaliacaoObjetivo](
	[IdAvaliacaoObjetivo] [int] IDENTITY(1,1) NOT NULL,
	[data] [date] NOT NULL,
	[peso] [numeric](5, 2) NOT NULL,
	[altura] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[pressaoArterial] [int] NOT NULL,
	[frequenciaCardiaca] [int] NULL,
	[temperatura] [numeric](5, 2) NULL,
	[saturacaoOxigenio] [int] NULL,
	[dataUltimaMestruacao] [date] NULL,
	[menopausa] [int] NULL,
	[IdMetodoContracetivo] [int] NULL,
	[DIU] [nvarchar](10) NULL,
	[concentracaoGlicoseSangue] [int] NULL,
	[AC] [int] NULL,
	[AP] [int] NULL,
	[INR] [int] NULL,
	[Menarca] [int] NULL,
	[gravidez] [int] NULL,
	[filhosVivos] [int] NULL,
	[abortos] [int] NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_AvaliacaoObjetivo] PRIMARY KEY CLUSTERED 
(
	[IdAvaliacaoObjetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvaliacaoObjetivoBebe]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvaliacaoObjetivoBebe](
	[IdAvaliacaoObjetivoBebe] [int] IDENTITY(1,1) NOT NULL,
	[dataRegisto] [date] NOT NULL,
	[Peso] [numeric](5, 2) NOT NULL,
	[Altura] [int] NOT NULL,
	[pressaoArterial] [int] NOT NULL,
	[frequenciaCardiaca] [int] NULL,
	[temperatura] [numeric](5, 2) NULL,
	[saturacaoOxigenio] [int] NULL,
	[INR] [int] NULL,
	[Perimetro] [int] NULL,
	[IdTipoAleitamento] [int] NULL,
	[nomeLeiteArtificial] [nvarchar](50) NULL,
	[IdTipoParto] [int] NULL,
	[partoDistocico] [nvarchar](20) NULL,
	[epidoral] [nvarchar](20) NULL,
	[episotomia] [nvarchar](20) NULL,
	[reanimacaoFetal] [nvarchar](20) NULL,
	[indiceAPGAR] [nvarchar](20) NULL,
	[Fototerapia] [nvarchar](20) NULL,
	[observacoes] [nvarchar](max) NULL,
	[IdPaciente] [int] NULL,
 CONSTRAINT [PK_AvaliacaoObjetivoBebe] PRIMARY KEY CLUSTERED 
(
	[IdAvaliacaoObjetivoBebe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cateterismo]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cateterismo](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[cateterismo] [nvarchar](500) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cateterismo] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cirurgia]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cirurgia](
	[IdCirurgia] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Caracterizacao] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cirurgia] PRIMARY KEY CLUSTERED 
(
	[IdCirurgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CirurgiaPaciente]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CirurgiaPaciente](
	[IdCirurgia] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_CirurgiaPaciente] PRIMARY KEY CLUSTERED 
(
	[IdCirurgia] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColheitadeSanguePrecoce]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColheitadeSanguePrecoce](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[idadeDias] [int] NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ColheitadeSanguePrecoce] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColheitaUrina]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColheitaUrina](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[exameSumario] [nvarchar](200) NULL,
	[urocultura] [nvarchar](500) NULL,
	[vinteQuantroHoras] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ColheitaUrina] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ColocacaoDIU]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColocacaoDIU](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[dataColocacaoDIU] [date] NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ColocacaoDIU] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colpocitologia]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colpocitologia](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[dvm] [nvarchar](max) NULL,
	[metodoContracetivoOral] [nvarchar](max) NULL,
	[metodoContracetivoDIUData] [date] NULL,
	[metodoContracetivoImplante] [nvarchar](max) NULL,
	[metodoContracetivoImplanteData] [date] NULL,
	[metodoContracetivoAnelVaginalData] [date] NULL,
	[metodoContracetivoPreservativos] [nvarchar](50) NULL,
	[metodoContracetivoIntramuscular] [nvarchar](max) NULL,
	[metodoContracetivoInstramuscularData] [date] NULL,
	[metodoContracetivoLaqTrompasData] [date] NULL,
	[metodoCOntracetivoPessarioData] [date] NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Colpocitologia] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[IdConsulta] [int] IDENTITY(1,1) NOT NULL,
	[dataConsulta] [date] NOT NULL,
	[horaInicioConsulta] [varchar](50) NOT NULL,
	[historiaAtual] [nvarchar](max) NULL,
	[sintomatologia] [nvarchar](max) NULL,
	[sinais] [nvarchar](max) NULL,
	[escalaDor] [varchar](50) NULL,
	[idPaciente] [int] NOT NULL,
	[idEnfermeiro] [int] NOT NULL,
	[valorConsulta] [decimal](6, 2) NULL,
	[horaFimConsulta] [nvarchar](50) NOT NULL,
	[diagnostico] [nvarchar](max) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[IdConsulta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsultaProdutoStock]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultaProdutoStock](
	[IdConsultaProdutoStock] [int] IDENTITY(1,1) NOT NULL,
	[IdProdutoStock] [int] NOT NULL,
	[quantidadeUsada] [int] NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ConsultaProdutoStock] PRIMARY KEY CLUSTERED 
(
	[IdConsultaProdutoStock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Crioterapia]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Crioterapia](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[localizacao] [nvarchar](max) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Crioterapia] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Desbridamento]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Desbridamento](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[antolitico] [nvarchar](max) NULL,
	[enzimatico] [nvarchar](max) NULL,
	[cirurgico] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Desbridamento] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Despesa]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Despesa](
	[IdDespesa] [int] IDENTITY(1,1) NOT NULL,
	[data] [date] NOT NULL,
	[valor] [numeric](6, 2) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
	[idTipoDespesa] [int] NOT NULL,
	[idEncomenda] [int] NULL,
 CONSTRAINT [PK_Despesa] PRIMARY KEY CLUSTERED 
(
	[IdDespesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doenca]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doenca](
	[IdDoenca] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Sintomas] [nvarchar](max) NULL,
 CONSTRAINT [PK_Doenca] PRIMARY KEY CLUSTERED 
(
	[IdDoenca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoencaPaciente]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoencaPaciente](
	[IdDoenca] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_DoencaPaciente] PRIMARY KEY CLUSTERED 
(
	[IdDoenca] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DopletFetal]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DopletFetal](
	[IdDoplerFetal] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NULL,
	[ig] [int] NULL,
	[dppData] [date] NULL,
	[dppcData] [date] NULL,
	[primeiraEcografia] [date] NULL,
	[escalaDor] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_DopletFetal] PRIMARY KEY CLUSTERED 
(
	[IdDoplerFetal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DrenagemLocas]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrenagemLocas](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[drenagemLocas] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_DrenagemLocas] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encomenda]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomenda](
	[IdEncomenda] [int] IDENTITY(1,1) NOT NULL,
	[idFornecedor] [int] NOT NULL,
	[Nfatura] [nvarchar](50) NOT NULL,
	[dataRegistoEncomenda] [date] NOT NULL,
	[dataEntregaPrevista] [date] NULL,
	[dataEntregaReal] [date] NULL,
	[pago] [bit] NULL,
 CONSTRAINT [PK_Encomenda] PRIMARY KEY CLUSTERED 
(
	[IdEncomenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enfermeiro]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enfermeiro](
	[IdEnfermeiro] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[funcao] [nvarchar](50) NULL,
	[contacto] [numeric](9, 0) NULL,
	[dataNascimento] [date] NULL,
	[username] [nvarchar](15) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[permissao] [int] NOT NULL,
	[passwordDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Enfermeiro] PRIMARY KEY CLUSTERED 
(
	[IdEnfermeiro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ENG]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ENG](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[numeroENG] [int] NULL,
	[dataENG] [date] NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ENG] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Espirometria]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Espirometria](
	[IdEspirometria] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[fev] [nvarchar](1000) NULL,
	[fvc] [nvarchar](1000) NULL,
	[fr] [int] NULL,
	[caracteristicaSuperficial] [nvarchar](50) NULL,
	[caracteristicaProfunda] [nvarchar](50) NULL,
	[caracteristicaAdbominal] [nvarchar](50) NULL,
	[caracteristicaToracica] [nvarchar](50) NULL,
	[caracteristicaMista] [nvarchar](50) NULL,
	[escalaDor] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Espirometria] PRIMARY KEY CLUSTERED 
(
	[IdEspirometria] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exame]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exame](
	[idPaciente] [int] NOT NULL,
	[idTipoExame] [int] NOT NULL,
	[data] [date] NOT NULL,
	[designacao] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Exame] PRIMARY KEY CLUSTERED 
(
	[idPaciente] ASC,
	[idTipoExame] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flebografia]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flebografia](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[flebografia] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Flebografia] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fornecedor](
	[IdFornecedor] [int] IDENTITY(1,1) NOT NULL,
	[nif] [int] NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[contacto] [int] NOT NULL,
	[email] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
	[rua] [nvarchar](max) NOT NULL,
	[numeroMorada] [int] NULL,
	[andarPiso] [nvarchar](50) NULL,
	[localidade] [nvarchar](50) NOT NULL,
	[bairroLocal] [nvarchar](100) NULL,
	[codPostalPrefixo] [nvarchar](4) NOT NULL,
	[codPostalSufixo] [nvarchar](3) NOT NULL,
	[designacao] [nvarchar](150) NULL,
 CONSTRAINT [PK_Fornecedor] PRIMARY KEY CLUSTERED 
(
	[IdFornecedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImplanteContracetivo]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImplanteContracetivo](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[dataColocacao] [date] NULL,
	[dataRetirada] [date] NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ImplanteContracetivo] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inalacoes]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inalacoes](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[O2] [nvarchar](max) NULL,
	[aerossol] [nvarchar](max) NULL,
	[inaladores] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Inalacoes] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LavagemAuricular]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LavagemAuricular](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[ouvidoDireito] [nvarchar](50) NULL,
	[ouvidoEsquerdo] [nvarchar](50) NULL,
	[ambos] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LavagemAuricular] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LavagemOcular]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LavagemOcular](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[olhoDireito] [nvarchar](50) NULL,
	[olhoEsquerdo] [nvarchar](50) NULL,
	[ambos] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LavagemOcular] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LavagemVesical]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LavagemVesical](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[lavagemVesical] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LavagemVesical] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LinhaEncomenda]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LinhaEncomenda](
	[IdLinhaEncomenda] [int] IDENTITY(1,1) NOT NULL,
	[quantidade] [int] NOT NULL,
	[idProdutoStock] [int] NOT NULL,
	[idEncomenda] [int] NOT NULL,
 CONSTRAINT [PK_LinhaEncomenda] PRIMARY KEY CLUSTERED 
(
	[IdLinhaEncomenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizacaoDor]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizacaoDor](
	[IdTratamentoMaosPes] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[localizacao] [nvarchar](max) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizacaoDor] PRIMARY KEY CLUSTERED 
(
	[IdTratamentoMaosPes] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizacaoDorConsulta]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizacaoDorConsulta](
	[IdLocalizacaoDor] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[localizacao] [nvarchar](max) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizacaoDorConsulta] PRIMARY KEY CLUSTERED 
(
	[IdLocalizacaoDor] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizacaoDorDopplerArterialVenoso]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizacaoDorDopplerArterialVenoso](
	[IdTratamento] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[localizacao] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizacaoDorDopplerArterialVenoso] PRIMARY KEY CLUSTERED 
(
	[IdTratamento] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizacaoDorDopplerFetal]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizacaoDorDopplerFetal](
	[IdTratamento] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[localizacao] [nvarchar](max) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizacaoDorDopplerFetal] PRIMARY KEY CLUSTERED 
(
	[IdTratamento] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizacaoDorEspirometria]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizacaoDorEspirometria](
	[IdTratamento] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[localizacao] [nvarchar](max) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizacaoDorEspirometria] PRIMARY KEY CLUSTERED 
(
	[IdTratamento] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocalizacaoDorVacinacao]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocalizacaoDorVacinacao](
	[IdTratamento] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[localizacao] [nvarchar](max) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_LocalizacaoDorVacinacao] PRIMARY KEY CLUSTERED 
(
	[IdTratamento] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicacao]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicacao](
	[IdMedicacao] [int] IDENTITY(1,1) NOT NULL,
	[medicamentos] [nvarchar](max) NOT NULL,
	[jejum] [nvarchar](50) NULL,
	[pequenoAlmoco] [nvarchar](50) NULL,
	[almoco] [nvarchar](50) NULL,
	[lanche] [nvarchar](50) NULL,
	[jantar] [nvarchar](50) NULL,
	[deitar] [nvarchar](50) NULL,
	[IdPaciente] [int] NULL,
	[data] [date] NOT NULL,
	[quantidadeJejum] [nvarchar](500) NULL,
	[quantidadePequenoAlmoco] [nvarchar](500) NULL,
	[quantidadeAlmoco] [nvarchar](500) NULL,
	[quantidadeLanche] [nvarchar](500) NULL,
	[quantidadeJantar] [nvarchar](500) NULL,
	[quantidadeDeitar] [nvarchar](500) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Medicacao] PRIMARY KEY CLUSTERED 
(
	[IdMedicacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetodoContracetivo]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetodoContracetivo](
	[IdMetodoContracetivo] [int] IDENTITY(1,1) NOT NULL,
	[nomeMetodoContracetivo] [nvarchar](max) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_MetodoContracetivo] PRIMARY KEY CLUSTERED 
(
	[IdMetodoContracetivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonitorizacaoECG]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonitorizacaoECG](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[monitorizacaoECG] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_MonitorizacaoECG] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[IdPaciente] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[Email] [nvarchar](500) NULL,
	[Contacto] [int] NOT NULL,
	[Nif] [int] NOT NULL,
	[Rua] [nvarchar](50) NOT NULL,
	[NumeroCasa] [int] NULL,
	[Andar] [nvarchar](50) NULL,
	[localidade] [nvarchar](50) NOT NULL,
	[bairroLocal] [nvarchar](100) NULL,
	[codPostalPrefixo] [nvarchar](4) NOT NULL,
	[codPostalSufixo] [nvarchar](3) NOT NULL,
	[designacao] [nvarchar](150) NULL,
	[IdEnfermeiro] [int] NOT NULL,
	[Acordo] [nvarchar](30) NOT NULL,
	[NomeSeguradora] [nvarchar](50) NULL,
	[NumeroApoliceSeguradora] [int] NULL,
	[NomeSubsistema] [nvarchar](50) NULL,
	[NumeroSubsistema] [int] NULL,
	[NumeroSNS] [int] NULL,
	[Sexo] [nvarchar](15) NULL,
	[PlanoVacinacao] [nvarchar](20) NULL,
	[IdProfissao] [int] NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[IdPaciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parto]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parto](
	[IdParto] [int] IDENTITY(1,1) NOT NULL,
	[tipoParto] [nvarchar](50) NOT NULL,
	[Observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Parto] PRIMARY KEY CLUSTERED 
(
	[IdParto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pressoterapia]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pressoterapia](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[membrosInferiores] [nvarchar](max) NULL,
	[membrosSuperiores] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Pressoterapia] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdutoStock]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdutoStock](
	[IdProdutoStock] [int] IDENTITY(1,1) NOT NULL,
	[NomeProduto] [nvarchar](max) NOT NULL,
	[quantidadeArmazenada] [int] NOT NULL,
	[taxaIVA] [int] NOT NULL,
	[precoUnitario] [numeric](5, 2) NOT NULL,
	[Observacoes] [nvarchar](max) NULL,
	[IdFornecedor] [int] NOT NULL,
 CONSTRAINT [PK_ProdutoStock] PRIMARY KEY CLUSTERED 
(
	[IdProdutoStock] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profissao]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profissao](
	[IdProfissao] [int] IDENTITY(1,1) NOT NULL,
	[nomeProfissao] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Profissao] PRIMARY KEY CLUSTERED 
(
	[IdProfissao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suturas]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suturas](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[id] [int] NULL,
	[natural] [int] NULL,
	[donatti] [int] NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Suturas] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TesteAcuidadeVisual]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TesteAcuidadeVisual](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[testeAcuidadeVisual] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TesteAcuidadeVisual] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TesteCombur]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TesteCombur](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[densidadeV1] [int] NULL,
	[densidadeV2] [int] NULL,
	[densidadeV3] [int] NULL,
	[densidadeV4] [int] NULL,
	[densidadeV5] [int] NULL,
	[densidadeV6] [int] NULL,
	[densidadeV7] [int] NULL,
	[ph] [int] NULL,
	[leucocitos ] [nvarchar](100) NULL,
	[nitritos] [nvarchar](100) NULL,
	[proteinas] [nvarchar](100) NULL,
	[glucose] [nvarchar](100) NULL,
	[cocetonicos] [nvarchar](100) NULL,
	[sangeHemoglobina] [nvarchar](100) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TesteCombur] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoDespesa]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoDespesa](
	[IdTipoDespesa] [int] IDENTITY(1,1) NOT NULL,
	[designacao] [nvarchar](50) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_tipoDespesa] PRIMARY KEY CLUSTERED 
(
	[IdTipoDespesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoExame]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoExame](
	[IdTipoExame] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[categoria] [nvarchar](50) NULL,
	[designacao] [nvarchar](50) NULL,
 CONSTRAINT [PK_tipoExame] PRIMARY KEY CLUSTERED 
(
	[IdTipoExame] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoQueimadura]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoQueimadura](
	[IdTipoQueimadura] [int] IDENTITY(1,1) NOT NULL,
	[tipoQueimadura] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tipoQueimadura] PRIMARY KEY CLUSTERED 
(
	[IdTipoQueimadura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipoUlcera]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoUlcera](
	[IdTipoUlcera] [int] IDENTITY(1,1) NOT NULL,
	[tipoUlcera] [nvarchar](50) NULL,
 CONSTRAINT [PK_tipoUlcera] PRIMARY KEY CLUSTERED 
(
	[IdTipoUlcera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamento]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamento](
	[IdTratamento] [int] IDENTITY(1,1) NOT NULL,
	[nomeTratamento] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdTratamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TratamentoExcisoes]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamentoExcisoes](
	[IdTratamento] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[numeroTratamento] [int] NULL,
	[corpoEstranho] [nvarchar](100) NULL,
	[dermica] [nvarchar](100) NULL,
	[Observacoes] [nvarchar](max) NULL,
	[dataProximoTratamento] [date] NULL,
 CONSTRAINT [PK_TratamentoExcisoes] PRIMARY KEY CLUSTERED 
(
	[IdTratamento] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TratamentoMaosPes]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamentoMaosPes](
	[IdTratamentoMaosPes] [int] IDENTITY(1,1) NOT NULL,
	[tratamento] [nvarchar](500) NOT NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_TratamentoMaosPes] PRIMARY KEY CLUSTERED 
(
	[IdTratamentoMaosPes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TratamentoPaciente]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamentoPaciente](
	[IdTratamento] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[numeroTratamento] [int] NULL,
	[dimensoes] [nvarchar](50) NULL,
	[grauUlceraPressao] [nvarchar](50) NULL,
	[exsudadoTipo] [nvarchar](50) NULL,
	[exsudadoQuantidade] [int] NULL,
	[exsudadoCheiro] [nvarchar](100) NULL,
	[tecidoPredominante ] [nvarchar](500) NULL,
	[areaCircundante] [nvarchar](100) NULL,
	[agenteLimpeza] [nvarchar](100) NULL,
	[aplicacaoFerida] [nvarchar](100) NULL,
	[aplicacaoAreaCircundante] [nvarchar](100) NULL,
	[aplicacaoPenso] [nvarchar](100) NULL,
	[aplicacaoTamanho] [int] NULL,
	[aplicacaoSuportePenso] [nvarchar](100) NULL,
	[ProximoTratamento] [date] NULL,
	[Observacoes] [nvarchar](max) NULL,
	[EscalaDor] [nvarchar](30) NULL,
	[tipoQueimadura] [int] NULL,
	[IPTB] [nvarchar](50) NULL,
	[tipoUlcera] [int] NULL,
 CONSTRAINT [PK_TratamentoPaciente] PRIMARY KEY CLUSTERED 
(
	[IdTratamento] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tricotomia]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tricotomia](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[tricotomia] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tricotomia] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vacinacao]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vacinacao](
	[IdVacinacao] [int] IDENTITY(1,1) NOT NULL,
	[IdPaciente] [int] NULL,
	[data] [date] NULL,
	[nomeVacina] [nvarchar](1000) NULL,
	[marcaComercial] [nvarchar](1000) NULL,
	[numeroInoculacao] [nvarchar](1000) NULL,
	[lote] [nvarchar](1000) NULL,
	[local] [nvarchar](1000) NULL,
	[escalaDor] [nvarchar](50) NULL,
	[observacoes] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVacinacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VariasAtitudes]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VariasAtitudes](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
 CONSTRAINT [PK_VariasAtitudes] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZaragatoaOnofaringe]    Script Date: 02/07/2020 17:41:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZaragatoaOnofaringe](
	[IdAtitude] [int] NOT NULL,
	[IdPaciente] [int] NOT NULL,
	[data] [date] NOT NULL,
	[zaragatoaOnofaringe] [nvarchar](max) NULL,
	[observacoes] [nvarchar](max) NULL,
 CONSTRAINT [PK_ZaragatoaOnofaringe] PRIMARY KEY CLUSTERED 
(
	[IdAtitude] ASC,
	[IdPaciente] ASC,
	[data] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[AgendamentoConsulta] ADD  DEFAULT ((0)) FOR [ConsultaRealizada]
GO
ALTER TABLE [dbo].[Encomenda] ADD  DEFAULT ((0)) FOR [pago]
GO
ALTER TABLE [dbo].[Enfermeiro] ADD  DEFAULT ((1)) FOR [permissao]
GO
ALTER TABLE [dbo].[Enfermeiro] ADD  DEFAULT ((1)) FOR [passwordDefault]
GO
ALTER TABLE [dbo].[AdministrarMedicacao]  WITH CHECK ADD  CONSTRAINT [FK_AdministrarMedicacao_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[AdministrarMedicacao] CHECK CONSTRAINT [FK_AdministrarMedicacao_Atitude]
GO
ALTER TABLE [dbo].[AdministrarMedicacao]  WITH CHECK ADD  CONSTRAINT [FK_AdministrarMedicacao_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AdministrarMedicacao] CHECK CONSTRAINT [FK_AdministrarMedicacao_Paciente]
GO
ALTER TABLE [dbo].[AgendamentoConsulta]  WITH CHECK ADD  CONSTRAINT [FK_AgendamentoConsulta_Enfermeiro] FOREIGN KEY([IdEnfermeiro])
REFERENCES [dbo].[Enfermeiro] ([IdEnfermeiro])
GO
ALTER TABLE [dbo].[AgendamentoConsulta] CHECK CONSTRAINT [FK_AgendamentoConsulta_Enfermeiro]
GO
ALTER TABLE [dbo].[AgendamentoConsulta]  WITH CHECK ADD  CONSTRAINT [FK_AgendamentoConsulta_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AgendamentoConsulta] CHECK CONSTRAINT [FK_AgendamentoConsulta_Paciente]
GO
ALTER TABLE [dbo].[AlergiaPaciente]  WITH CHECK ADD  CONSTRAINT [FK_AlergiaPaciente_Alergia] FOREIGN KEY([IdAlergia])
REFERENCES [dbo].[Alergia] ([IdAlergia])
GO
ALTER TABLE [dbo].[AlergiaPaciente] CHECK CONSTRAINT [FK_AlergiaPaciente_Alergia]
GO
ALTER TABLE [dbo].[AlergiaPaciente]  WITH CHECK ADD  CONSTRAINT [FK_AlergiaPaciente_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AlergiaPaciente] CHECK CONSTRAINT [FK_AlergiaPaciente_Paciente]
GO
ALTER TABLE [dbo].[Algariacao]  WITH CHECK ADD  CONSTRAINT [FK_Algariacao_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Algariacao] CHECK CONSTRAINT [FK_Algariacao_Atitude]
GO
ALTER TABLE [dbo].[Algariacao]  WITH CHECK ADD  CONSTRAINT [FK_Algariacao_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Algariacao] CHECK CONSTRAINT [FK_Algariacao_Paciente]
GO
ALTER TABLE [dbo].[analisesLaboratoriaisPaciente]  WITH CHECK ADD  CONSTRAINT [FK_analisesLaboratoriaisPaciente_Analises] FOREIGN KEY([IdAnalisesLaboratoriais])
REFERENCES [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais])
GO
ALTER TABLE [dbo].[analisesLaboratoriaisPaciente] CHECK CONSTRAINT [FK_analisesLaboratoriaisPaciente_Analises]
GO
ALTER TABLE [dbo].[analisesLaboratoriaisPaciente]  WITH CHECK ADD  CONSTRAINT [FK_analisesLaboratoriaisPaciente_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[analisesLaboratoriaisPaciente] CHECK CONSTRAINT [FK_analisesLaboratoriaisPaciente_Paciente]
GO
ALTER TABLE [dbo].[AspiracaoSecrecao]  WITH CHECK ADD  CONSTRAINT [FK_AspiracaoSecrecao_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[AspiracaoSecrecao] CHECK CONSTRAINT [FK_AspiracaoSecrecao_Atitude]
GO
ALTER TABLE [dbo].[AspiracaoSecrecao]  WITH CHECK ADD  CONSTRAINT [FK_AspiracaoSecrecao_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AspiracaoSecrecao] CHECK CONSTRAINT [FK_AspiracaoSecrecao_Paciente]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivo]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoObjetivo_MetodoContracetivo] FOREIGN KEY([IdMetodoContracetivo])
REFERENCES [dbo].[MetodoContracetivo] ([IdMetodoContracetivo])
GO
ALTER TABLE [dbo].[AvaliacaoObjetivo] CHECK CONSTRAINT [FK_AvaliacaoObjetivo_MetodoContracetivo]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivo]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoObjetivo_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AvaliacaoObjetivo] CHECK CONSTRAINT [FK_AvaliacaoObjetivo_Paciente]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoObjetivoBebe_Aleitamento] FOREIGN KEY([IdTipoAleitamento])
REFERENCES [dbo].[Aleitamento] ([IdAleitamento])
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe] CHECK CONSTRAINT [FK_AvaliacaoObjetivoBebe_Aleitamento]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoObjetivoBebe_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe] CHECK CONSTRAINT [FK_AvaliacaoObjetivoBebe_Paciente]
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe]  WITH CHECK ADD  CONSTRAINT [FK_AvaliacaoObjetivoBebe_Parto] FOREIGN KEY([IdTipoParto])
REFERENCES [dbo].[Parto] ([IdParto])
GO
ALTER TABLE [dbo].[AvaliacaoObjetivoBebe] CHECK CONSTRAINT [FK_AvaliacaoObjetivoBebe_Parto]
GO
ALTER TABLE [dbo].[CirurgiaPaciente]  WITH CHECK ADD  CONSTRAINT [FK_CirurgiaPaciente_Cirurgia] FOREIGN KEY([IdCirurgia])
REFERENCES [dbo].[Cirurgia] ([IdCirurgia])
GO
ALTER TABLE [dbo].[CirurgiaPaciente] CHECK CONSTRAINT [FK_CirurgiaPaciente_Cirurgia]
GO
ALTER TABLE [dbo].[CirurgiaPaciente]  WITH CHECK ADD  CONSTRAINT [FK_CirurgiaPaciente_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[CirurgiaPaciente] CHECK CONSTRAINT [FK_CirurgiaPaciente_Paciente]
GO
ALTER TABLE [dbo].[ColheitadeSanguePrecoce]  WITH CHECK ADD  CONSTRAINT [FK_ColheitadeSanguePrecoce_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[ColheitadeSanguePrecoce] CHECK CONSTRAINT [FK_ColheitadeSanguePrecoce_Atitude]
GO
ALTER TABLE [dbo].[ColheitadeSanguePrecoce]  WITH CHECK ADD  CONSTRAINT [FK_ColheitadeSanguePrecoce_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ColheitadeSanguePrecoce] CHECK CONSTRAINT [FK_ColheitadeSanguePrecoce_Paciente]
GO
ALTER TABLE [dbo].[ColheitaUrina]  WITH CHECK ADD  CONSTRAINT [FK_ColheitaUrina_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[ColheitaUrina] CHECK CONSTRAINT [FK_ColheitaUrina_Atitude]
GO
ALTER TABLE [dbo].[ColheitaUrina]  WITH CHECK ADD  CONSTRAINT [FK_ColheitaUrina_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ColheitaUrina] CHECK CONSTRAINT [FK_ColheitaUrina_Paciente]
GO
ALTER TABLE [dbo].[ColocacaoDIU]  WITH CHECK ADD  CONSTRAINT [FK_ColocacaoDIU_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[ColocacaoDIU] CHECK CONSTRAINT [FK_ColocacaoDIU_Atitude]
GO
ALTER TABLE [dbo].[ColocacaoDIU]  WITH CHECK ADD  CONSTRAINT [FK_ColocacaoDIU_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ColocacaoDIU] CHECK CONSTRAINT [FK_ColocacaoDIU_Paciente]
GO
ALTER TABLE [dbo].[Colpocitologia]  WITH CHECK ADD  CONSTRAINT [FK_Colpocitologia_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Colpocitologia] CHECK CONSTRAINT [FK_Colpocitologia_Atitude]
GO
ALTER TABLE [dbo].[Colpocitologia]  WITH CHECK ADD  CONSTRAINT [FK_Colpocitologia_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Colpocitologia] CHECK CONSTRAINT [FK_Colpocitologia_Paciente]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Enfermeiro] FOREIGN KEY([idEnfermeiro])
REFERENCES [dbo].[Enfermeiro] ([IdEnfermeiro])
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Enfermeiro]
GO
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY([idPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Paciente]
GO
ALTER TABLE [dbo].[ConsultaProdutoStock]  WITH CHECK ADD  CONSTRAINT [FK_ConsultaProdutoStock_ProdutoStock] FOREIGN KEY([IdProdutoStock])
REFERENCES [dbo].[ProdutoStock] ([IdProdutoStock])
GO
ALTER TABLE [dbo].[ConsultaProdutoStock] CHECK CONSTRAINT [FK_ConsultaProdutoStock_ProdutoStock]
GO
ALTER TABLE [dbo].[Crioterapia]  WITH CHECK ADD  CONSTRAINT [FK_Crioterapia_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Crioterapia] CHECK CONSTRAINT [FK_Crioterapia_Atitude]
GO
ALTER TABLE [dbo].[Crioterapia]  WITH CHECK ADD  CONSTRAINT [FK_Crioterapia_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Crioterapia] CHECK CONSTRAINT [FK_Crioterapia_Paciente]
GO
ALTER TABLE [dbo].[Desbridamento]  WITH CHECK ADD  CONSTRAINT [FK_Desbridamento_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Desbridamento] CHECK CONSTRAINT [FK_Desbridamento_Atitude]
GO
ALTER TABLE [dbo].[Desbridamento]  WITH CHECK ADD  CONSTRAINT [FK_Desbridamento_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Desbridamento] CHECK CONSTRAINT [FK_Desbridamento_Paciente]
GO
ALTER TABLE [dbo].[Despesa]  WITH CHECK ADD  CONSTRAINT [FK_Despesa_Encomenda] FOREIGN KEY([idEncomenda])
REFERENCES [dbo].[Encomenda] ([IdEncomenda])
GO
ALTER TABLE [dbo].[Despesa] CHECK CONSTRAINT [FK_Despesa_Encomenda]
GO
ALTER TABLE [dbo].[Despesa]  WITH CHECK ADD  CONSTRAINT [FK_Despesa_TipoDespesa] FOREIGN KEY([idTipoDespesa])
REFERENCES [dbo].[tipoDespesa] ([IdTipoDespesa])
GO
ALTER TABLE [dbo].[Despesa] CHECK CONSTRAINT [FK_Despesa_TipoDespesa]
GO
ALTER TABLE [dbo].[DoencaPaciente]  WITH CHECK ADD  CONSTRAINT [FK_DoencaPaciente_Doenca] FOREIGN KEY([IdDoenca])
REFERENCES [dbo].[Doenca] ([IdDoenca])
GO
ALTER TABLE [dbo].[DoencaPaciente] CHECK CONSTRAINT [FK_DoencaPaciente_Doenca]
GO
ALTER TABLE [dbo].[DoencaPaciente]  WITH CHECK ADD  CONSTRAINT [FK_DoencaPaciente_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[DoencaPaciente] CHECK CONSTRAINT [FK_DoencaPaciente_Paciente]
GO
ALTER TABLE [dbo].[DopletFetal]  WITH CHECK ADD  CONSTRAINT [FK_DopletFetal_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[DopletFetal] CHECK CONSTRAINT [FK_DopletFetal_Paciente]
GO
ALTER TABLE [dbo].[DrenagemLocas]  WITH CHECK ADD  CONSTRAINT [FK_DrenagemLocas_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[DrenagemLocas] CHECK CONSTRAINT [FK_DrenagemLocas_Atitude]
GO
ALTER TABLE [dbo].[DrenagemLocas]  WITH CHECK ADD  CONSTRAINT [FK_DrenagemLocas_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[DrenagemLocas] CHECK CONSTRAINT [FK_DrenagemLocas_Paciente]
GO
ALTER TABLE [dbo].[Encomenda]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_Fornecedor] FOREIGN KEY([idFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[Encomenda] CHECK CONSTRAINT [FK_Encomenda_Fornecedor]
GO
ALTER TABLE [dbo].[ENG]  WITH CHECK ADD  CONSTRAINT [FK_ENG_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[ENG] CHECK CONSTRAINT [FK_ENG_Atitude]
GO
ALTER TABLE [dbo].[ENG]  WITH CHECK ADD  CONSTRAINT [FK_ENG_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ENG] CHECK CONSTRAINT [FK_ENG_Paciente]
GO
ALTER TABLE [dbo].[Espirometria]  WITH CHECK ADD  CONSTRAINT [FK_Espirometria_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Espirometria] CHECK CONSTRAINT [FK_Espirometria_Paciente]
GO
ALTER TABLE [dbo].[Exame]  WITH CHECK ADD  CONSTRAINT [FK_Exame_Paciente] FOREIGN KEY([idPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Exame] CHECK CONSTRAINT [FK_Exame_Paciente]
GO
ALTER TABLE [dbo].[Exame]  WITH CHECK ADD  CONSTRAINT [FK_Exame_TipoExame] FOREIGN KEY([idTipoExame])
REFERENCES [dbo].[tipoExame] ([IdTipoExame])
GO
ALTER TABLE [dbo].[Exame] CHECK CONSTRAINT [FK_Exame_TipoExame]
GO
ALTER TABLE [dbo].[Flebografia]  WITH CHECK ADD  CONSTRAINT [FK_Flebografia_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Flebografia] CHECK CONSTRAINT [FK_Flebografia_Atitude]
GO
ALTER TABLE [dbo].[Flebografia]  WITH CHECK ADD  CONSTRAINT [FK_Flebografia_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Flebografia] CHECK CONSTRAINT [FK_Flebografia_Paciente]
GO
ALTER TABLE [dbo].[ImplanteContracetivo]  WITH CHECK ADD  CONSTRAINT [FK_ImplanteContracetivo_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[ImplanteContracetivo] CHECK CONSTRAINT [FK_ImplanteContracetivo_Atitude]
GO
ALTER TABLE [dbo].[ImplanteContracetivo]  WITH CHECK ADD  CONSTRAINT [FK_ImplanteContracetivo_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ImplanteContracetivo] CHECK CONSTRAINT [FK_ImplanteContracetivo_Paciente]
GO
ALTER TABLE [dbo].[Inalacoes]  WITH CHECK ADD  CONSTRAINT [FK_Inalacoes_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Inalacoes] CHECK CONSTRAINT [FK_Inalacoes_Atitude]
GO
ALTER TABLE [dbo].[Inalacoes]  WITH CHECK ADD  CONSTRAINT [FK_Inalacoes_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Inalacoes] CHECK CONSTRAINT [FK_Inalacoes_Paciente]
GO
ALTER TABLE [dbo].[LavagemAuricular]  WITH CHECK ADD  CONSTRAINT [FK_LavagemAuricular_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[LavagemAuricular] CHECK CONSTRAINT [FK_LavagemAuricular_Atitude]
GO
ALTER TABLE [dbo].[LavagemAuricular]  WITH CHECK ADD  CONSTRAINT [FK_LavagemAuricular_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LavagemAuricular] CHECK CONSTRAINT [FK_LavagemAuricular_Paciente]
GO
ALTER TABLE [dbo].[LavagemOcular]  WITH CHECK ADD  CONSTRAINT [FK_LavagemOcular_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[LavagemOcular] CHECK CONSTRAINT [FK_LavagemOcular_Atitude]
GO
ALTER TABLE [dbo].[LavagemOcular]  WITH CHECK ADD  CONSTRAINT [FK_LavagemOcular_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LavagemOcular] CHECK CONSTRAINT [FK_LavagemOcular_Paciente]
GO
ALTER TABLE [dbo].[LavagemVesical]  WITH CHECK ADD  CONSTRAINT [FK_LavagemVesical_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[LavagemVesical] CHECK CONSTRAINT [FK_LavagemVesical_Atitude]
GO
ALTER TABLE [dbo].[LavagemVesical]  WITH CHECK ADD  CONSTRAINT [FK_LavagemVesical_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LavagemVesical] CHECK CONSTRAINT [FK_LavagemVesical_Paciente]
GO
ALTER TABLE [dbo].[LinhaEncomenda]  WITH CHECK ADD  CONSTRAINT [FK_LinhaEncomenda_Encomenda] FOREIGN KEY([idEncomenda])
REFERENCES [dbo].[Encomenda] ([IdEncomenda])
GO
ALTER TABLE [dbo].[LinhaEncomenda] CHECK CONSTRAINT [FK_LinhaEncomenda_Encomenda]
GO
ALTER TABLE [dbo].[LinhaEncomenda]  WITH CHECK ADD  CONSTRAINT [FK_LinhaEncomenda_ProdutoStock] FOREIGN KEY([idProdutoStock])
REFERENCES [dbo].[ProdutoStock] ([IdProdutoStock])
GO
ALTER TABLE [dbo].[LinhaEncomenda] CHECK CONSTRAINT [FK_LinhaEncomenda_ProdutoStock]
GO
ALTER TABLE [dbo].[LocalizacaoDor]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoDor_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LocalizacaoDor] CHECK CONSTRAINT [FK_LocalizacaoDor_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDor]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoDor_TratamentoMaosPes] FOREIGN KEY([IdTratamentoMaosPes])
REFERENCES [dbo].[TratamentoMaosPes] ([IdTratamentoMaosPes])
GO
ALTER TABLE [dbo].[LocalizacaoDor] CHECK CONSTRAINT [FK_LocalizacaoDor_TratamentoMaosPes]
GO
ALTER TABLE [dbo].[LocalizacaoDorConsulta]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoDorConsulta_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LocalizacaoDorConsulta] CHECK CONSTRAINT [FK_LocalizacaoDorConsulta_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorDopplerArterialVenoso]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoDorDopplerArterialVenoso_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LocalizacaoDorDopplerArterialVenoso] CHECK CONSTRAINT [FK_LocalizacaoDorDopplerArterialVenoso_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorDopplerFetal]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoDorDopplerFetal_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LocalizacaoDorDopplerFetal] CHECK CONSTRAINT [FK_LocalizacaoDorDopplerFetal_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorEspirometria]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoDorEspirometria_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LocalizacaoDorEspirometria] CHECK CONSTRAINT [FK_LocalizacaoDorEspirometria_Paciente]
GO
ALTER TABLE [dbo].[LocalizacaoDorVacinacao]  WITH CHECK ADD  CONSTRAINT [FK_LocalizacaoDorVacinacao_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[LocalizacaoDorVacinacao] CHECK CONSTRAINT [FK_LocalizacaoDorVacinacao_Paciente]
GO
ALTER TABLE [dbo].[Medicacao]  WITH CHECK ADD  CONSTRAINT [FK_Medicacao_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Medicacao] CHECK CONSTRAINT [FK_Medicacao_Paciente]
GO
ALTER TABLE [dbo].[MonitorizacaoECG]  WITH CHECK ADD  CONSTRAINT [FK_MonitorizacaoECG_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[MonitorizacaoECG] CHECK CONSTRAINT [FK_MonitorizacaoECG_Atitude]
GO
ALTER TABLE [dbo].[MonitorizacaoECG]  WITH CHECK ADD  CONSTRAINT [FK_MonitorizacaoECG_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[MonitorizacaoECG] CHECK CONSTRAINT [FK_MonitorizacaoECG_Paciente]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Enfermeiro] FOREIGN KEY([IdEnfermeiro])
REFERENCES [dbo].[Enfermeiro] ([IdEnfermeiro])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Enfermeiro]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Profissao] FOREIGN KEY([IdProfissao])
REFERENCES [dbo].[Profissao] ([IdProfissao])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Profissao]
GO
ALTER TABLE [dbo].[Pressoterapia]  WITH CHECK ADD  CONSTRAINT [FK_Pressoterapia_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Pressoterapia] CHECK CONSTRAINT [FK_Pressoterapia_Atitude]
GO
ALTER TABLE [dbo].[Pressoterapia]  WITH CHECK ADD  CONSTRAINT [FK_Pressoterapia_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Pressoterapia] CHECK CONSTRAINT [FK_Pressoterapia_Paciente]
GO
ALTER TABLE [dbo].[ProdutoStock]  WITH CHECK ADD  CONSTRAINT [FK_ProdutoStock_Fornecedor] FOREIGN KEY([IdFornecedor])
REFERENCES [dbo].[Fornecedor] ([IdFornecedor])
GO
ALTER TABLE [dbo].[ProdutoStock] CHECK CONSTRAINT [FK_ProdutoStock_Fornecedor]
GO
ALTER TABLE [dbo].[Suturas]  WITH CHECK ADD  CONSTRAINT [FK_Suturas_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Suturas] CHECK CONSTRAINT [FK_Suturas_Atitude]
GO
ALTER TABLE [dbo].[Suturas]  WITH CHECK ADD  CONSTRAINT [FK_Suturas_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Suturas] CHECK CONSTRAINT [FK_Suturas_Paciente]
GO
ALTER TABLE [dbo].[TesteAcuidadeVisual]  WITH CHECK ADD  CONSTRAINT [FK_TesteAcuidadeVisual_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[TesteAcuidadeVisual] CHECK CONSTRAINT [FK_TesteAcuidadeVisual_Atitude]
GO
ALTER TABLE [dbo].[TesteAcuidadeVisual]  WITH CHECK ADD  CONSTRAINT [FK_TesteAcuidadeVisual_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[TesteAcuidadeVisual] CHECK CONSTRAINT [FK_TesteAcuidadeVisual_Paciente]
GO
ALTER TABLE [dbo].[TesteCombur]  WITH CHECK ADD  CONSTRAINT [FK_TesteCombur_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[TesteCombur] CHECK CONSTRAINT [FK_TesteCombur_Atitude]
GO
ALTER TABLE [dbo].[TesteCombur]  WITH CHECK ADD  CONSTRAINT [FK_TesteCombur_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[TesteCombur] CHECK CONSTRAINT [FK_TesteCombur_Paciente]
GO
ALTER TABLE [dbo].[TratamentoExcisoes]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoExcisoes_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[TratamentoExcisoes] CHECK CONSTRAINT [FK_TratamentoExcisoes_Paciente]
GO
ALTER TABLE [dbo].[TratamentoExcisoes]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoExcisoes_Tratamento] FOREIGN KEY([IdTratamento])
REFERENCES [dbo].[Tratamento] ([IdTratamento])
GO
ALTER TABLE [dbo].[TratamentoExcisoes] CHECK CONSTRAINT [FK_TratamentoExcisoes_Tratamento]
GO
ALTER TABLE [dbo].[TratamentoPaciente]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoPaciente_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[TratamentoPaciente] CHECK CONSTRAINT [FK_TratamentoPaciente_Paciente]
GO
ALTER TABLE [dbo].[TratamentoPaciente]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoPaciente_Queimadura] FOREIGN KEY([tipoQueimadura])
REFERENCES [dbo].[tipoQueimadura] ([IdTipoQueimadura])
GO
ALTER TABLE [dbo].[TratamentoPaciente] CHECK CONSTRAINT [FK_TratamentoPaciente_Queimadura]
GO
ALTER TABLE [dbo].[TratamentoPaciente]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoPaciente_Tratamento] FOREIGN KEY([IdTratamento])
REFERENCES [dbo].[Tratamento] ([IdTratamento])
GO
ALTER TABLE [dbo].[TratamentoPaciente] CHECK CONSTRAINT [FK_TratamentoPaciente_Tratamento]
GO
ALTER TABLE [dbo].[TratamentoPaciente]  WITH CHECK ADD  CONSTRAINT [FK_TratamentoPaciente_Ulcera] FOREIGN KEY([tipoUlcera])
REFERENCES [dbo].[tipoUlcera] ([IdTipoUlcera])
GO
ALTER TABLE [dbo].[TratamentoPaciente] CHECK CONSTRAINT [FK_TratamentoPaciente_Ulcera]
GO
ALTER TABLE [dbo].[Tricotomia]  WITH CHECK ADD  CONSTRAINT [FK_Tricotomia_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[Tricotomia] CHECK CONSTRAINT [FK_Tricotomia_Atitude]
GO
ALTER TABLE [dbo].[Tricotomia]  WITH CHECK ADD  CONSTRAINT [FK_Tricotomia_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Tricotomia] CHECK CONSTRAINT [FK_Tricotomia_Paciente]
GO
ALTER TABLE [dbo].[Vacinacao]  WITH CHECK ADD  CONSTRAINT [FK_Vacinacao_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[Vacinacao] CHECK CONSTRAINT [FK_Vacinacao_Paciente]
GO
ALTER TABLE [dbo].[VariasAtitudes]  WITH CHECK ADD  CONSTRAINT [FK_VariasAtitudes_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[VariasAtitudes] CHECK CONSTRAINT [FK_VariasAtitudes_Atitude]
GO
ALTER TABLE [dbo].[VariasAtitudes]  WITH CHECK ADD  CONSTRAINT [FK_VariasAtitudes_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[VariasAtitudes] CHECK CONSTRAINT [FK_VariasAtitudes_Paciente]
GO
ALTER TABLE [dbo].[ZaragatoaOnofaringe]  WITH CHECK ADD  CONSTRAINT [FK_ZaragatoaOnofaringe_Atitude] FOREIGN KEY([IdAtitude])
REFERENCES [dbo].[Atitude] ([IdAtitude])
GO
ALTER TABLE [dbo].[ZaragatoaOnofaringe] CHECK CONSTRAINT [FK_ZaragatoaOnofaringe_Atitude]
GO
ALTER TABLE [dbo].[ZaragatoaOnofaringe]  WITH CHECK ADD  CONSTRAINT [FK_ZaragatoaOnofaringe_Paciente] FOREIGN KEY([IdPaciente])
REFERENCES [dbo].[Paciente] ([IdPaciente])
GO
ALTER TABLE [dbo].[ZaragatoaOnofaringe] CHECK CONSTRAINT [FK_ZaragatoaOnofaringe_Paciente]
GO
