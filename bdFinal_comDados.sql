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
/****** Object:  Index [UQ__tmp_ms_x__C7D1D6C847A6B707]    Script Date: 02/07/2020 17:38:56 ******/
ALTER TABLE [dbo].[Paciente] DROP CONSTRAINT [UQ__tmp_ms_x__C7D1D6C847A6B707]
GO
/****** Object:  Index [UQ__Enfermei__F3DBC572B042EF0B]    Script Date: 02/07/2020 17:38:56 ******/
ALTER TABLE [dbo].[Enfermeiro] DROP CONSTRAINT [UQ__Enfermei__F3DBC572B042EF0B]
GO
/****** Object:  Index [UQ__Enfermei__AB6E6164129AC889]    Script Date: 02/07/2020 17:38:56 ******/
ALTER TABLE [dbo].[Enfermeiro] DROP CONSTRAINT [UQ__Enfermei__AB6E6164129AC889]
GO
/****** Object:  Table [dbo].[ZaragatoaOnofaringe]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZaragatoaOnofaringe]') AND type in (N'U'))
DROP TABLE [dbo].[ZaragatoaOnofaringe]
GO
/****** Object:  Table [dbo].[VariasAtitudes]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[VariasAtitudes]') AND type in (N'U'))
DROP TABLE [dbo].[VariasAtitudes]
GO
/****** Object:  Table [dbo].[Vacinacao]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Vacinacao]') AND type in (N'U'))
DROP TABLE [dbo].[Vacinacao]
GO
/****** Object:  Table [dbo].[Tricotomia]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tricotomia]') AND type in (N'U'))
DROP TABLE [dbo].[Tricotomia]
GO
/****** Object:  Table [dbo].[TratamentoPaciente]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TratamentoPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[TratamentoPaciente]
GO
/****** Object:  Table [dbo].[TratamentoMaosPes]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TratamentoMaosPes]') AND type in (N'U'))
DROP TABLE [dbo].[TratamentoMaosPes]
GO
/****** Object:  Table [dbo].[TratamentoExcisoes]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TratamentoExcisoes]') AND type in (N'U'))
DROP TABLE [dbo].[TratamentoExcisoes]
GO
/****** Object:  Table [dbo].[Tratamento]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tratamento]') AND type in (N'U'))
DROP TABLE [dbo].[Tratamento]
GO
/****** Object:  Table [dbo].[tipoUlcera]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoUlcera]') AND type in (N'U'))
DROP TABLE [dbo].[tipoUlcera]
GO
/****** Object:  Table [dbo].[tipoQueimadura]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoQueimadura]') AND type in (N'U'))
DROP TABLE [dbo].[tipoQueimadura]
GO
/****** Object:  Table [dbo].[tipoExame]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoExame]') AND type in (N'U'))
DROP TABLE [dbo].[tipoExame]
GO
/****** Object:  Table [dbo].[tipoDespesa]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tipoDespesa]') AND type in (N'U'))
DROP TABLE [dbo].[tipoDespesa]
GO
/****** Object:  Table [dbo].[TesteCombur]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TesteCombur]') AND type in (N'U'))
DROP TABLE [dbo].[TesteCombur]
GO
/****** Object:  Table [dbo].[TesteAcuidadeVisual]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TesteAcuidadeVisual]') AND type in (N'U'))
DROP TABLE [dbo].[TesteAcuidadeVisual]
GO
/****** Object:  Table [dbo].[Suturas]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suturas]') AND type in (N'U'))
DROP TABLE [dbo].[Suturas]
GO
/****** Object:  Table [dbo].[Profissao]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Profissao]') AND type in (N'U'))
DROP TABLE [dbo].[Profissao]
GO
/****** Object:  Table [dbo].[ProdutoStock]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProdutoStock]') AND type in (N'U'))
DROP TABLE [dbo].[ProdutoStock]
GO
/****** Object:  Table [dbo].[Pressoterapia]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pressoterapia]') AND type in (N'U'))
DROP TABLE [dbo].[Pressoterapia]
GO
/****** Object:  Table [dbo].[Parto]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parto]') AND type in (N'U'))
DROP TABLE [dbo].[Parto]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paciente]') AND type in (N'U'))
DROP TABLE [dbo].[Paciente]
GO
/****** Object:  Table [dbo].[MonitorizacaoECG]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonitorizacaoECG]') AND type in (N'U'))
DROP TABLE [dbo].[MonitorizacaoECG]
GO
/****** Object:  Table [dbo].[MetodoContracetivo]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MetodoContracetivo]') AND type in (N'U'))
DROP TABLE [dbo].[MetodoContracetivo]
GO
/****** Object:  Table [dbo].[Medicacao]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Medicacao]') AND type in (N'U'))
DROP TABLE [dbo].[Medicacao]
GO
/****** Object:  Table [dbo].[LocalizacaoDorVacinacao]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorVacinacao]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorVacinacao]
GO
/****** Object:  Table [dbo].[LocalizacaoDorEspirometria]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorEspirometria]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorEspirometria]
GO
/****** Object:  Table [dbo].[LocalizacaoDorDopplerFetal]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorDopplerFetal]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorDopplerFetal]
GO
/****** Object:  Table [dbo].[LocalizacaoDorDopplerArterialVenoso]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorDopplerArterialVenoso]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorDopplerArterialVenoso]
GO
/****** Object:  Table [dbo].[LocalizacaoDorConsulta]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDorConsulta]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDorConsulta]
GO
/****** Object:  Table [dbo].[LocalizacaoDor]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LocalizacaoDor]') AND type in (N'U'))
DROP TABLE [dbo].[LocalizacaoDor]
GO
/****** Object:  Table [dbo].[LinhaEncomenda]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LinhaEncomenda]') AND type in (N'U'))
DROP TABLE [dbo].[LinhaEncomenda]
GO
/****** Object:  Table [dbo].[LavagemVesical]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LavagemVesical]') AND type in (N'U'))
DROP TABLE [dbo].[LavagemVesical]
GO
/****** Object:  Table [dbo].[LavagemOcular]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LavagemOcular]') AND type in (N'U'))
DROP TABLE [dbo].[LavagemOcular]
GO
/****** Object:  Table [dbo].[LavagemAuricular]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LavagemAuricular]') AND type in (N'U'))
DROP TABLE [dbo].[LavagemAuricular]
GO
/****** Object:  Table [dbo].[Inalacoes]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Inalacoes]') AND type in (N'U'))
DROP TABLE [dbo].[Inalacoes]
GO
/****** Object:  Table [dbo].[ImplanteContracetivo]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImplanteContracetivo]') AND type in (N'U'))
DROP TABLE [dbo].[ImplanteContracetivo]
GO
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Fornecedor]') AND type in (N'U'))
DROP TABLE [dbo].[Fornecedor]
GO
/****** Object:  Table [dbo].[Flebografia]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Flebografia]') AND type in (N'U'))
DROP TABLE [dbo].[Flebografia]
GO
/****** Object:  Table [dbo].[Exame]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exame]') AND type in (N'U'))
DROP TABLE [dbo].[Exame]
GO
/****** Object:  Table [dbo].[Espirometria]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Espirometria]') AND type in (N'U'))
DROP TABLE [dbo].[Espirometria]
GO
/****** Object:  Table [dbo].[ENG]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ENG]') AND type in (N'U'))
DROP TABLE [dbo].[ENG]
GO
/****** Object:  Table [dbo].[Enfermeiro]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Enfermeiro]') AND type in (N'U'))
DROP TABLE [dbo].[Enfermeiro]
GO
/****** Object:  Table [dbo].[Encomenda]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Encomenda]') AND type in (N'U'))
DROP TABLE [dbo].[Encomenda]
GO
/****** Object:  Table [dbo].[DrenagemLocas]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DrenagemLocas]') AND type in (N'U'))
DROP TABLE [dbo].[DrenagemLocas]
GO
/****** Object:  Table [dbo].[DopletFetal]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DopletFetal]') AND type in (N'U'))
DROP TABLE [dbo].[DopletFetal]
GO
/****** Object:  Table [dbo].[DoencaPaciente]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DoencaPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[DoencaPaciente]
GO
/****** Object:  Table [dbo].[Doenca]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Doenca]') AND type in (N'U'))
DROP TABLE [dbo].[Doenca]
GO
/****** Object:  Table [dbo].[Despesa]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Despesa]') AND type in (N'U'))
DROP TABLE [dbo].[Despesa]
GO
/****** Object:  Table [dbo].[Desbridamento]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Desbridamento]') AND type in (N'U'))
DROP TABLE [dbo].[Desbridamento]
GO
/****** Object:  Table [dbo].[Crioterapia]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Crioterapia]') AND type in (N'U'))
DROP TABLE [dbo].[Crioterapia]
GO
/****** Object:  Table [dbo].[ConsultaProdutoStock]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConsultaProdutoStock]') AND type in (N'U'))
DROP TABLE [dbo].[ConsultaProdutoStock]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Consulta]') AND type in (N'U'))
DROP TABLE [dbo].[Consulta]
GO
/****** Object:  Table [dbo].[Colpocitologia]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Colpocitologia]') AND type in (N'U'))
DROP TABLE [dbo].[Colpocitologia]
GO
/****** Object:  Table [dbo].[ColocacaoDIU]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColocacaoDIU]') AND type in (N'U'))
DROP TABLE [dbo].[ColocacaoDIU]
GO
/****** Object:  Table [dbo].[ColheitaUrina]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColheitaUrina]') AND type in (N'U'))
DROP TABLE [dbo].[ColheitaUrina]
GO
/****** Object:  Table [dbo].[ColheitadeSanguePrecoce]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ColheitadeSanguePrecoce]') AND type in (N'U'))
DROP TABLE [dbo].[ColheitadeSanguePrecoce]
GO
/****** Object:  Table [dbo].[CirurgiaPaciente]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CirurgiaPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[CirurgiaPaciente]
GO
/****** Object:  Table [dbo].[Cirurgia]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cirurgia]') AND type in (N'U'))
DROP TABLE [dbo].[Cirurgia]
GO
/****** Object:  Table [dbo].[Cateterismo]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cateterismo]') AND type in (N'U'))
DROP TABLE [dbo].[Cateterismo]
GO
/****** Object:  Table [dbo].[AvaliacaoObjetivoBebe]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AvaliacaoObjetivoBebe]') AND type in (N'U'))
DROP TABLE [dbo].[AvaliacaoObjetivoBebe]
GO
/****** Object:  Table [dbo].[AvaliacaoObjetivo]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AvaliacaoObjetivo]') AND type in (N'U'))
DROP TABLE [dbo].[AvaliacaoObjetivo]
GO
/****** Object:  Table [dbo].[Atitude]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Atitude]') AND type in (N'U'))
DROP TABLE [dbo].[Atitude]
GO
/****** Object:  Table [dbo].[AspiracaoSecrecao]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AspiracaoSecrecao]') AND type in (N'U'))
DROP TABLE [dbo].[AspiracaoSecrecao]
GO
/****** Object:  Table [dbo].[analisesLaboratoriaisPaciente]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[analisesLaboratoriaisPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[analisesLaboratoriaisPaciente]
GO
/****** Object:  Table [dbo].[analisesLaboratoriais]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[analisesLaboratoriais]') AND type in (N'U'))
DROP TABLE [dbo].[analisesLaboratoriais]
GO
/****** Object:  Table [dbo].[Algariacao]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Algariacao]') AND type in (N'U'))
DROP TABLE [dbo].[Algariacao]
GO
/****** Object:  Table [dbo].[AlergiaPaciente]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AlergiaPaciente]') AND type in (N'U'))
DROP TABLE [dbo].[AlergiaPaciente]
GO
/****** Object:  Table [dbo].[Alergia]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Alergia]') AND type in (N'U'))
DROP TABLE [dbo].[Alergia]
GO
/****** Object:  Table [dbo].[Aleitamento]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Aleitamento]') AND type in (N'U'))
DROP TABLE [dbo].[Aleitamento]
GO
/****** Object:  Table [dbo].[AgendamentoConsulta]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AgendamentoConsulta]') AND type in (N'U'))
DROP TABLE [dbo].[AgendamentoConsulta]
GO
/****** Object:  Table [dbo].[AdministrarMedicacao]    Script Date: 02/07/2020 17:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AdministrarMedicacao]') AND type in (N'U'))
DROP TABLE [dbo].[AdministrarMedicacao]
GO
/****** Object:  Table [dbo].[AdministrarMedicacao]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[AgendamentoConsulta]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Aleitamento]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Alergia]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[AlergiaPaciente]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Algariacao]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[analisesLaboratoriais]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[analisesLaboratoriaisPaciente]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[AspiracaoSecrecao]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Atitude]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[AvaliacaoObjetivo]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[AvaliacaoObjetivoBebe]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Cateterismo]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Cirurgia]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[CirurgiaPaciente]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[ColheitadeSanguePrecoce]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[ColheitaUrina]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[ColocacaoDIU]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Colpocitologia]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Consulta]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[ConsultaProdutoStock]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Crioterapia]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Desbridamento]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Despesa]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Doenca]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[DoencaPaciente]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[DopletFetal]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[DrenagemLocas]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Encomenda]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Enfermeiro]    Script Date: 02/07/2020 17:38:56 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ENG]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Espirometria]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Exame]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Flebografia]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Fornecedor]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[ImplanteContracetivo]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Inalacoes]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LavagemAuricular]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LavagemOcular]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LavagemVesical]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LinhaEncomenda]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LocalizacaoDor]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LocalizacaoDorConsulta]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LocalizacaoDorDopplerArterialVenoso]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LocalizacaoDorDopplerFetal]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LocalizacaoDorEspirometria]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[LocalizacaoDorVacinacao]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Medicacao]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[MetodoContracetivo]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[MonitorizacaoECG]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Paciente]    Script Date: 02/07/2020 17:38:56 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parto]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Pressoterapia]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[ProdutoStock]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Profissao]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Suturas]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[TesteAcuidadeVisual]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[TesteCombur]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[tipoDespesa]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[tipoExame]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[tipoQueimadura]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[tipoUlcera]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Tratamento]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[TratamentoExcisoes]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[TratamentoMaosPes]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[TratamentoPaciente]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Tricotomia]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[Vacinacao]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[VariasAtitudes]    Script Date: 02/07/2020 17:38:56 ******/
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
/****** Object:  Table [dbo].[ZaragatoaOnofaringe]    Script Date: 02/07/2020 17:38:56 ******/
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
INSERT [dbo].[AdministrarMedicacao] ([IdAtitude], [IdPaciente], [data], [PO], [retal], [intradermica], [intramuscular], [endovenosa], [subcutanea], [topicoViaCutanea], [topicoEfeitoLocal], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-01' AS Date), N'Sim', N'Sim', N'Sim', N'fdfd', N'df', NULL, N'Sim', N'Sim', N'sfd')
INSERT [dbo].[AdministrarMedicacao] ([IdAtitude], [IdPaciente], [data], [PO], [retal], [intradermica], [intramuscular], [endovenosa], [subcutanea], [topicoViaCutanea], [topicoEfeitoLocal], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-03' AS Date), N'Sim', N'Sim', N'Sim', N'hj', N'hjh', N'Sim', N'Sim', NULL, N'hj')
INSERT [dbo].[AdministrarMedicacao] ([IdAtitude], [IdPaciente], [data], [PO], [retal], [intradermica], [intramuscular], [endovenosa], [subcutanea], [topicoViaCutanea], [topicoEfeitoLocal], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-10' AS Date), NULL, N'Sim', NULL, NULL, NULL, NULL, NULL, N'Sim', NULL)
INSERT [dbo].[AdministrarMedicacao] ([IdAtitude], [IdPaciente], [data], [PO], [retal], [intradermica], [intramuscular], [endovenosa], [subcutanea], [topicoViaCutanea], [topicoEfeitoLocal], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-13' AS Date), NULL, N'Sim', NULL, NULL, NULL, NULL, NULL, N'Sim', N'med')
GO
SET IDENTITY_INSERT [dbo].[AgendamentoConsulta] ON 

INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (62, N'15:03', CAST(N'2020-04-07' AS Date), 4029, 5005, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (63, N'15:03', CAST(N'2020-04-08' AS Date), 4030, 5005, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (102, N'15:03', CAST(N'2020-07-04' AS Date), 4029, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (133, N'15:03', CAST(N'2020-04-07' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (134, N'15:03', CAST(N'2020-04-07' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (135, N'15:03', CAST(N'2020-04-07' AS Date), 4021, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (136, N'15:03', CAST(N'2020-04-07' AS Date), 2006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (137, N'15:03', CAST(N'2020-04-07' AS Date), 2006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (138, N'15:03', CAST(N'2020-04-07' AS Date), 2006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1149, N'15:03', CAST(N'2020-04-28' AS Date), 4023, 4003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1150, N'15:03', CAST(N'2020-04-30' AS Date), 3006, 4003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1151, N'15:03', CAST(N'2020-05-08' AS Date), 3006, 4003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1152, N'15:03', CAST(N'2020-04-07' AS Date), 6013, 4006, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1153, N'15:03', CAST(N'2020-04-08' AS Date), 6013, 4006, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1154, N'23:58', CAST(N'2020-04-08' AS Date), 3006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1155, N'02:19', CAST(N'2020-04-08' AS Date), 3008, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1156, N'00:22', CAST(N'2020-04-08' AS Date), 3006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1157, N'02:20', CAST(N'2020-04-08' AS Date), 3008, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (1158, N'00:25', CAST(N'2020-04-08' AS Date), 4023, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (2104, N'06:37', CAST(N'2020-04-08' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (2105, N'07:37', CAST(N'2020-04-08' AS Date), 4011, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (2106, N'02:41', CAST(N'2020-04-08' AS Date), 4010, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (2107, N'00:47', CAST(N'2020-04-08' AS Date), 4010, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (3104, N'12:49', CAST(N'2020-04-08' AS Date), 7014, 5005, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (3106, N'18:52', CAST(N'2020-04-08' AS Date), 4029, 5005, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (4104, N'23:32', CAST(N'2020-04-16' AS Date), 7014, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (4105, N'19:39', CAST(N'2020-04-09' AS Date), 4029, 5005, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (4106, N'19:39', CAST(N'2020-04-24' AS Date), 4029, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (4107, N'19:41', CAST(N'2020-04-09' AS Date), 4011, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (4110, N'21:49', CAST(N'2020-04-08' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (4113, N'12:51', CAST(N'2020-04-08' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (4114, N'12:51', CAST(N'2020-04-09' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (5104, N'22:20', CAST(N'2020-04-08' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (5105, N'01:20', CAST(N'2020-04-09' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (6104, N'22:02', CAST(N'2020-04-08' AS Date), 4016, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (7105, N'23:58', CAST(N'2020-04-08' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (8104, N'02:52', CAST(N'2020-04-09' AS Date), 1002, 3002, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (8105, N'10:53', CAST(N'2020-04-09' AS Date), 3006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (8106, N'05:54', CAST(N'2020-04-09' AS Date), 3008, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (8107, N'03:54', CAST(N'2020-04-09' AS Date), 1002, 3002, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (9104, N'16:27', CAST(N'2020-04-09' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (9105, N'15:27', CAST(N'2020-04-09' AS Date), 4014, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (9106, N'15:46', CAST(N'2020-04-09' AS Date), 8013, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (10104, N'12:30', CAST(N'2020-04-10' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (10107, N'12:34', CAST(N'2020-04-10' AS Date), 7015, 5005, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (10108, N'14:34', CAST(N'2020-04-10' AS Date), 4029, 5005, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (11104, N'15:07', CAST(N'2020-04-11' AS Date), 3008, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (13106, N'21:20', CAST(N'2020-04-10' AS Date), 3006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (13108, N'22:20', CAST(N'2020-04-10' AS Date), 3006, 4003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (14106, N'23:26', CAST(N'2020-04-10' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (14107, N'23:30', CAST(N'2020-04-10' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (15104, N'03:27', CAST(N'2020-04-11' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (16104, N'12:55', CAST(N'2020-04-11' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (16105, N'13:55', CAST(N'2020-04-11' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (16106, N'16:55', CAST(N'2020-04-11' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (16107, N'18:55', CAST(N'2020-04-11' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (17104, N'11:53', CAST(N'2020-04-12' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (17105, N'14:53', CAST(N'2020-04-12' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (17106, N'14:52', CAST(N'2020-04-12' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (17107, N'16:52', CAST(N'2020-04-12' AS Date), 8013, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (17108, N'17:51', CAST(N'2020-04-12' AS Date), 8013, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (20104, N'09:15', CAST(N'2020-04-14' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (20105, N'10:15', CAST(N'2020-04-14' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (22105, N'18:18', CAST(N'2020-04-14' AS Date), 4016, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (22106, N'18:22', CAST(N'2020-04-14' AS Date), 4021, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (22107, N'19:18', CAST(N'2020-04-14' AS Date), 4014, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (23104, N'19:17', CAST(N'2020-04-14' AS Date), 1002, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (23105, N'19:18', CAST(N'2020-04-14' AS Date), 4, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (24104, N'21:44', CAST(N'2020-04-14' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (24105, N'21:53', CAST(N'2020-04-14' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (25108, N'01:18', CAST(N'2020-04-15' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (29113, N'02:38', CAST(N'2020-04-18' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (30114, N'08:36', CAST(N'2020-04-19' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (30115, N'03:44', CAST(N'2020-04-18' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (31113, N'23:26', CAST(N'2020-04-21' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (32113, N'13:50', CAST(N'2020-04-29' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (32114, N'15:50', CAST(N'2020-04-29' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (32115, N'17:50', CAST(N'2020-04-29' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (32116, N'14:51', CAST(N'2020-04-29' AS Date), 4014, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (33113, N'15:19', CAST(N'2020-04-29' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (34113, N'20:33', CAST(N'2020-05-08' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (34114, N'19:34', CAST(N'2020-05-08' AS Date), 11027, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (34115, N'21:41', CAST(N'2020-05-08' AS Date), 10027, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (35113, N'23:26', CAST(N'2020-05-08' AS Date), 4029, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36113, N'13:51', CAST(N'2020-05-09' AS Date), 4029, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36114, N'14:00', CAST(N'2020-05-09' AS Date), 4030, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36115, N'14:45', CAST(N'2020-05-09' AS Date), 7014, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36116, N'15:30', CAST(N'2020-05-09' AS Date), 7015, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36117, N'16:15', CAST(N'2020-05-09' AS Date), 7016, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36118, N'17:00', CAST(N'2020-05-09' AS Date), 9014, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36119, N'17:45', CAST(N'2020-05-09' AS Date), 12027, 5005, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36120, N'13:00', CAST(N'2020-05-09' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36121, N'13:30', CAST(N'2020-05-09' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36122, N'14:00', CAST(N'2020-05-09' AS Date), 4010, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36123, N'14:30', CAST(N'2020-05-09' AS Date), 4011, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36124, N'15:00', CAST(N'2020-05-09' AS Date), 4014, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36125, N'15:30', CAST(N'2020-05-09' AS Date), 4016, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36126, N'16:00', CAST(N'2020-05-09' AS Date), 4020, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36127, N'16:30', CAST(N'2020-05-09' AS Date), 4021, 3003, 0)
GO
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36128, N'17:00', CAST(N'2020-05-09' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36129, N'17:30', CAST(N'2020-05-09' AS Date), 10026, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36130, N'18:00', CAST(N'2020-05-09' AS Date), 10027, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (36131, N'18:30', CAST(N'2020-05-09' AS Date), 11027, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (37113, N'16:08', CAST(N'2020-05-11' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (37114, N'17:07', CAST(N'2020-05-11' AS Date), 13027, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (37115, N'16:09', CAST(N'2020-05-11' AS Date), 1005, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (37116, N'17:13', CAST(N'2020-05-11' AS Date), 10027, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (37117, N'23:00', CAST(N'2020-05-11' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (38117, N'17:16', CAST(N'2020-05-13' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (38118, N'17:16', CAST(N'2020-05-14' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (38119, N'18:16', CAST(N'2020-05-14' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (38120, N'18:16', CAST(N'2020-05-20' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (38121, N'16:19', CAST(N'2020-05-13' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (39117, N'16:43', CAST(N'2020-05-14' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (39118, N'21:48', CAST(N'2020-05-14' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40117, N'13:12', CAST(N'2020-05-15' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40118, N'13:12', CAST(N'2020-05-16' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40119, N'14:14', CAST(N'2020-05-15' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40120, N'15:11', CAST(N'2020-05-15' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40121, N'16:16', CAST(N'2020-05-15' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40122, N'17:13', CAST(N'2020-05-15' AS Date), 4016, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40123, N'21:35', CAST(N'2020-05-15' AS Date), 4014, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (40124, N'20:42', CAST(N'2020-05-15' AS Date), 4010, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (41117, N'09:06', CAST(N'2020-05-16' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (41118, N'21:49', CAST(N'2020-05-18' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (41119, N'22:54', CAST(N'2020-05-18' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (41120, N'18:34', CAST(N'2020-05-19' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (41121, N'18:35', CAST(N'2020-05-19' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (42120, N'23:38', CAST(N'2020-05-21' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (42121, N'23:39', CAST(N'2020-05-21' AS Date), 4, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (42122, N'23:40', CAST(N'2020-05-21' AS Date), 1002, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (42123, N'23:45', CAST(N'2020-05-21' AS Date), 1005, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (43120, N'12:17', CAST(N'2020-05-22' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (43121, N'13:17', CAST(N'2020-05-22' AS Date), 4, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (43122, N'14:16', CAST(N'2020-05-22' AS Date), 1002, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (43123, N'15:17', CAST(N'2020-05-22' AS Date), 1005, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (43124, N'16:17', CAST(N'2020-05-22' AS Date), 13027, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (43125, N'17:17', CAST(N'2020-05-22' AS Date), 18034, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (44120, N'23:43', CAST(N'2020-05-24' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (44121, N'23:46', CAST(N'2020-05-24' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (44122, N'23:47', CAST(N'2020-05-24' AS Date), 1002, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (44123, N'23:50', CAST(N'2020-05-24' AS Date), 1004, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (45120, N'12:56', CAST(N'2020-05-26' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (46120, N'23:36', CAST(N'2020-05-30' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (46121, N'23:37', CAST(N'2020-05-30' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (46122, N'23:39', CAST(N'2020-05-30' AS Date), 4011, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (46123, N'23:40', CAST(N'2020-05-30' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (47120, N'18:50', CAST(N'2020-06-02' AS Date), 1, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (48120, N'22:32', CAST(N'2020-06-05' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (49120, N'23:47', CAST(N'2020-06-06' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (49121, N'23:50', CAST(N'2020-06-06' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (50120, N'03:02', CAST(N'2020-06-07' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (50121, N'10:02', CAST(N'2020-06-07' AS Date), 4014, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (51120, N'00:24', CAST(N'2020-06-08' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (52120, N'01:12', CAST(N'2020-06-09' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (53120, N'23:28', CAST(N'2020-06-09' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (53121, N'09:29', CAST(N'2020-06-10' AS Date), 4009, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (54120, N'20:51', CAST(N'2020-06-10' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (54121, N'04:52', CAST(N'2020-06-11' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (55121, N'12:52', CAST(N'2020-06-11' AS Date), 4021, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (55122, N'13:53', CAST(N'2020-06-11' AS Date), 13028, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (56121, N'16:33', CAST(N'2020-06-11' AS Date), 4020, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (57121, N'09:17', CAST(N'2020-06-12' AS Date), 8013, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (58121, N'17:46', CAST(N'2020-06-12' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (59121, N'22:42', CAST(N'2020-06-12' AS Date), 10027, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (59122, N'07:07', CAST(N'2020-06-13' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (60121, N'19:54', CAST(N'2020-06-13' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (61121, N'15:15', CAST(N'2020-06-18' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (62121, N'12:25', CAST(N'2020-06-24' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (63121, N'18:07', CAST(N'2020-06-26' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (63122, N'19:07', CAST(N'2020-06-26' AS Date), 11027, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (64121, N'10:52', CAST(N'2020-06-27' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (65121, N'09:14', CAST(N'2020-06-28' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (66121, N'19:29', CAST(N'2020-06-28' AS Date), 4021, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (67121, N'09:00', CAST(N'2020-06-29' AS Date), 8013, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (68121, N'16:14', CAST(N'2020-06-29' AS Date), 4016, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (68122, N'17:14', CAST(N'2020-06-30' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (68123, N'17:14', CAST(N'2020-07-01' AS Date), 1006, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (68124, N'16:14', CAST(N'2020-07-01' AS Date), 4011, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (68125, N'18:19', CAST(N'2020-06-29' AS Date), 1006, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (69121, N'19:30', CAST(N'2020-06-29' AS Date), 4009, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (69122, N'20:44', CAST(N'2020-06-29' AS Date), 4014, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (69123, N'20:00', CAST(N'2020-06-29' AS Date), 19034, 3003, 1)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (70121, N'06:34', CAST(N'2020-06-30' AS Date), 4016, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (71121, N'16:50', CAST(N'2020-07-01' AS Date), 11027, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (71122, N'17:52', CAST(N'2020-07-01' AS Date), 19032, 3003, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (72121, N'18:00', CAST(N'2020-07-01' AS Date), 1002, 3002, 0)
INSERT [dbo].[AgendamentoConsulta] ([IdMarcacao], [horaProximaConsulta], [dataProximaConsulta], [IdPaciente], [IdEnfermeiro], [ConsultaRealizada]) VALUES (73121, N'02:03', CAST(N'2020-07-02' AS Date), 4011, 3003, 0)
SET IDENTITY_INSERT [dbo].[AgendamentoConsulta] OFF
GO
SET IDENTITY_INSERT [dbo].[Aleitamento] ON 

INSERT [dbo].[Aleitamento] ([IdAleitamento], [tipoAleitamento], [Observacoes]) VALUES (1, N'Artificial', N'Leite de compra')
INSERT [dbo].[Aleitamento] ([IdAleitamento], [tipoAleitamento], [Observacoes]) VALUES (2, N'Materno', N'Leite só da mãe')
INSERT [dbo].[Aleitamento] ([IdAleitamento], [tipoAleitamento], [Observacoes]) VALUES (3, N'Misto', N'Leite de compra e leite da mãe.')
INSERT [dbo].[Aleitamento] ([IdAleitamento], [tipoAleitamento], [Observacoes]) VALUES (1002, N'Aleitamento 1', N'teste de validações')
INSERT [dbo].[Aleitamento] ([IdAleitamento], [tipoAleitamento], [Observacoes]) VALUES (1003, N'aaaaa', N'')
SET IDENTITY_INSERT [dbo].[Aleitamento] OFF
GO
SET IDENTITY_INSERT [dbo].[Alergia] ON 

INSERT [dbo].[Alergia] ([IdAlergia], [Nome], [Sintomas]) VALUES (3008, N'Alergia Pólen', N'Garganta irritada, comichã no nariz, espirros, tosse, entre outros...')
INSERT [dbo].[Alergia] ([IdAlergia], [Nome], [Sintomas]) VALUES (3009, N'Alergia 2', N'')
SET IDENTITY_INSERT [dbo].[Alergia] OFF
GO
INSERT [dbo].[Algariacao] ([IdAtitude], [IdPaciente], [data], [silastic], [folley], [tresVias], [dataProximaRealgariacao], [observacoes]) VALUES (1034, 4011, CAST(N'2020-07-01' AS Date), 89, NULL, N'Sim', NULL, N'opopo')
GO
SET IDENTITY_INSERT [dbo].[analisesLaboratoriais] ON 

INSERT [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais], [NomeAnalise], [Observacoes]) VALUES (1, N'Análise ao Sangue', NULL)
INSERT [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais], [NomeAnalise], [Observacoes]) VALUES (2, N'Analise ao plasma', NULL)
INSERT [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais], [NomeAnalise], [Observacoes]) VALUES (3, N'Análise ao Sangue 2', N'nada')
INSERT [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais], [NomeAnalise], [Observacoes]) VALUES (1002, N'dfgnb', NULL)
INSERT [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais], [NomeAnalise], [Observacoes]) VALUES (1003, N'analise à urina', NULL)
INSERT [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais], [NomeAnalise], [Observacoes]) VALUES (1004, N'sadfg', NULL)
INSERT [dbo].[analisesLaboratoriais] ([IdAnalisesLaboratoriais], [NomeAnalise], [Observacoes]) VALUES (1005, N'2222', NULL)
SET IDENTITY_INSERT [dbo].[analisesLaboratoriais] OFF
GO
INSERT [dbo].[analisesLaboratoriaisPaciente] ([IdAnalisesLaboratoriais], [IdPaciente], [data], [resultados], [observacoes]) VALUES (1, 1006, CAST(N'2020-04-02' AS Date), NULL, NULL)
INSERT [dbo].[analisesLaboratoriaisPaciente] ([IdAnalisesLaboratoriais], [IdPaciente], [data], [resultados], [observacoes]) VALUES (1, 4009, CAST(N'2020-05-26' AS Date), NULL, NULL)
INSERT [dbo].[analisesLaboratoriaisPaciente] ([IdAnalisesLaboratoriais], [IdPaciente], [data], [resultados], [observacoes]) VALUES (2, 1006, CAST(N'2020-03-26' AS Date), N'sdd', NULL)
INSERT [dbo].[analisesLaboratoriaisPaciente] ([IdAnalisesLaboratoriais], [IdPaciente], [data], [resultados], [observacoes]) VALUES (2, 4009, CAST(N'2020-05-26' AS Date), NULL, NULL)
INSERT [dbo].[analisesLaboratoriaisPaciente] ([IdAnalisesLaboratoriais], [IdPaciente], [data], [resultados], [observacoes]) VALUES (3, 1006, CAST(N'2020-05-24' AS Date), N'sdd', NULL)
INSERT [dbo].[analisesLaboratoriaisPaciente] ([IdAnalisesLaboratoriais], [IdPaciente], [data], [resultados], [observacoes]) VALUES (3, 4009, CAST(N'2020-03-25' AS Date), N'dfgh', NULL)
GO
INSERT [dbo].[AspiracaoSecrecao] ([IdAtitude], [IdPaciente], [data], [aspiracao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-11' AS Date), N'fyt', N'yty')
INSERT [dbo].[AspiracaoSecrecao] ([IdAtitude], [IdPaciente], [data], [aspiracao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-13' AS Date), N'ijo', N'uiou')
GO
SET IDENTITY_INSERT [dbo].[Atitude] ON 

INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (1, N'Administrar Medicação', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (3, N'Aspiração secreções ', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (4, N'Audiograma', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (5, N'Cateterismo', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (6, N'Colheita expectoração', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (7, N'Colheita exsudado zaragatoa', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (8, N'Colheita fezes parasitológico', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (9, N'Colheita fezes sangue oculto', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (10, N'Colheita sangue', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (11, N'Colheita de sangue diagnóstico precoce', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (12, N'Colheita urina', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (13, N'Colpocitologia', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (14, N'Colocação DIU', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (15, N'Crioterapia', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (16, N'Drenagem locas', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (17, N'Desbridamento', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (18, N'Enema limpeza', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (19, N'ENG', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (20, N'Flebografia', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (21, N'Inalações', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (22, N'Implante Contracetivo SubDermico', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (23, N'Lavagem Auricular', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (24, N'Lavagem Gástrica', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (25, N'Lavagem Ocular', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (26, N'Lavagem Vesical', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (27, N'Monitorização ECG', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (28, N'Pressoterapia', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (29, N'Suturas', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (30, N'Teste Combur (urina) ', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (31, N'Teste Avaliação Acuidade Visual', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (32, N'Tricotomia', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (33, N'Zaragatoa Onofaringe', N'')
INSERT [dbo].[Atitude] ([IdAtitude], [nomeAtitude], [observacoes]) VALUES (1034, N'Algariação', NULL)
SET IDENTITY_INSERT [dbo].[Atitude] OFF
GO
SET IDENTITY_INSERT [dbo].[AvaliacaoObjetivo] ON 

INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (14, CAST(N'2020-03-29' AS Date), CAST(64.00 AS Numeric(5, 2)), 157, 1006, 12, 90, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (18, CAST(N'2020-03-29' AS Date), CAST(64.00 AS Numeric(5, 2)), 158, 1006, 12, 90, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (19, CAST(N'2020-03-29' AS Date), CAST(64.00 AS Numeric(5, 2)), 159, 1006, 12, 90, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (20, CAST(N'2020-03-29' AS Date), CAST(67.00 AS Numeric(5, 2)), 157, 1006, 12, 90, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (1012, CAST(N'2020-03-29' AS Date), CAST(65.00 AS Numeric(5, 2)), 157, 1006, 12, 85, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (2012, CAST(N'2020-04-14' AS Date), CAST(68.00 AS Numeric(5, 2)), 157, 1006, 12, 85, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (3012, CAST(N'2020-03-29' AS Date), CAST(64.00 AS Numeric(5, 2)), 157, 1002, 12, 85, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (4012, CAST(N'2020-04-14' AS Date), CAST(60.00 AS Numeric(5, 2)), 157, 4016, 12, 85, CAST(37.00 AS Numeric(5, 2)), 202, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (5012, CAST(N'2020-03-29' AS Date), CAST(1.00 AS Numeric(5, 2)), 1, 1006, 12, 85, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (5013, CAST(N'2020-03-29' AS Date), CAST(1.00 AS Numeric(5, 2)), 40, 1006, 12, 85, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (5014, CAST(N'2020-04-15' AS Date), CAST(1.00 AS Numeric(5, 2)), 40, 1006, 12, 85, CAST(37.00 AS Numeric(5, 2)), 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (5015, CAST(N'2020-05-09' AS Date), CAST(60.00 AS Numeric(5, 2)), 153, 1006, 60, 90, CAST(37.00 AS Numeric(5, 2)), 50, CAST(N'2020-04-26' AS Date), 0, 1, N'Não', 2, 2, 2, 2, 12, 2, 2, 0, N'observações')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (5016, CAST(N'2020-05-09' AS Date), CAST(80.00 AS Numeric(5, 2)), 180, 4010, 50, 75, CAST(37.00 AS Numeric(5, 2)), 46, NULL, 0, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (5017, CAST(N'2020-05-09' AS Date), CAST(85.00 AS Numeric(5, 2)), 158, 4010, 50, 90, CAST(37.00 AS Numeric(5, 2)), 52, NULL, 0, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (6015, CAST(N'2020-05-11' AS Date), CAST(80.00 AS Numeric(5, 2)), 180, 10027, 50, 80, CAST(37.00 AS Numeric(5, 2)), 45, NULL, 0, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (6016, CAST(N'2020-05-11' AS Date), CAST(63.00 AS Numeric(5, 2)), 163, 1006, 20, 90, CAST(37.00 AS Numeric(5, 2)), 20, CAST(N'2020-04-27' AS Date), 0, 6, N'Sim', 0, 0, 0, 0, 0, 0, 0, 0, N'')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (7016, CAST(N'2020-05-15' AS Date), CAST(37.00 AS Numeric(5, 2)), 130, 4009, 20, NULL, NULL, NULL, CAST(N'2020-05-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (7017, CAST(N'2020-05-15' AS Date), CAST(37.00 AS Numeric(5, 2)), 130, 4009, 20, NULL, NULL, NULL, CAST(N'2020-05-09' AS Date), NULL, 6, N'Sim', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (7018, CAST(N'2020-05-15' AS Date), CAST(63.00 AS Numeric(5, 2)), 168, 4009, 30, NULL, NULL, NULL, CAST(N'2020-05-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 2, 0, 0, N'')
INSERT [dbo].[AvaliacaoObjetivo] ([IdAvaliacaoObjetivo], [data], [peso], [altura], [IdPaciente], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [dataUltimaMestruacao], [menopausa], [IdMetodoContracetivo], [DIU], [concentracaoGlicoseSangue], [AC], [AP], [INR], [Menarca], [gravidez], [filhosVivos], [abortos], [observacoes]) VALUES (8019, CAST(N'2020-06-13' AS Date), CAST(3.00 AS Numeric(5, 2)), 3, 1006, 3, 3, CAST(3.00 AS Numeric(5, 2)), 3, CAST(N'2020-05-09' AS Date), 3, 2, N'Não', 3, 3, 3, 3, 3, 3, 3, 0, N'gfh')
SET IDENTITY_INSERT [dbo].[AvaliacaoObjetivo] OFF
GO
SET IDENTITY_INSERT [dbo].[AvaliacaoObjetivoBebe] ON 

INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1, CAST(N'2020-05-12' AS Date), CAST(20.00 AS Numeric(5, 2)), 25, 0, NULL, CAST(0.00 AS Numeric(5, 2)), 0, 0, 0, 3, N'', 2, NULL, NULL, NULL, NULL, NULL, NULL, N'', 1006)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2, CAST(N'2020-05-12' AS Date), CAST(23.00 AS Numeric(5, 2)), 20, 0, NULL, CAST(0.00 AS Numeric(5, 2)), 0, 0, 0, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 1006)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1002, CAST(N'2020-05-12' AS Date), CAST(20.00 AS Numeric(5, 2)), 50, 20, NULL, CAST(37.00 AS Numeric(5, 2)), 20, 20, 30, 2, N'', 1, NULL, N'Não', N'Não', N'Não', N'1º Minuto', N'Não', N'', 1006)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1003, CAST(N'2020-05-12' AS Date), CAST(20.00 AS Numeric(5, 2)), 50, 20, NULL, CAST(37.00 AS Numeric(5, 2)), 20, 20, 30, 3, N'nome do leite', 2, N'Ventosa', N'Não', N'Não', N'Não', N'1º Minuto', N'Não', N'', 1006)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1006, CAST(N'2020-05-15' AS Date), CAST(1.00 AS Numeric(5, 2)), 1, 1, NULL, NULL, NULL, NULL, NULL, 1, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 4009)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1007, CAST(N'2020-05-15' AS Date), CAST(1.00 AS Numeric(5, 2)), 2, 1, NULL, NULL, NULL, NULL, NULL, 1, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 4009)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1008, CAST(N'2020-05-15' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, NULL, 1, N'dfghj', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 4009)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1009, CAST(N'2020-05-15' AS Date), CAST(10.00 AS Numeric(5, 2)), 10, 10, NULL, NULL, NULL, NULL, NULL, 1, N'gfghghgf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 4009)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1010, CAST(N'2020-05-15' AS Date), CAST(30.00 AS Numeric(5, 2)), 26, 20, NULL, NULL, NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 4009)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1011, CAST(N'2020-05-20' AS Date), CAST(30.00 AS Numeric(5, 2)), 26, 20, NULL, NULL, NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 4009)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (1012, CAST(N'2020-05-15' AS Date), CAST(1.00 AS Numeric(5, 2)), 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 4009)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2013, CAST(N'2020-06-13' AS Date), CAST(1.00 AS Numeric(5, 2)), 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2014, CAST(N'2020-06-12' AS Date), CAST(1.00 AS Numeric(5, 2)), 1, 1, 1, NULL, NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2017, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, 2, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2018, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, 2, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2019, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, 2, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2020, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, NULL, 1002, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2021, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, 2, NULL, NULL, NULL, NULL, 1, N'gfhfh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2022, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, NULL, 1002, N'', 1002, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2023, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, NULL, 1002, N'', 2, N'Ventosa', NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2024, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, NULL, 1002, N'', 2, N'Fórceps', NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2025, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, N'', NULL, NULL, N'Não', N'Sim', N'Sim', NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (2026, CAST(N'2020-06-13' AS Date), CAST(2.00 AS Numeric(5, 2)), 2, 2, NULL, NULL, NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, N'5º Minuto', N'Não', N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (3013, CAST(N'2020-06-13' AS Date), CAST(1.00 AS Numeric(5, 2)), 1, 1, NULL, CAST(1.00 AS Numeric(5, 2)), NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (3014, CAST(N'2020-06-13' AS Date), CAST(3.00 AS Numeric(5, 2)), 3, 3, NULL, CAST(3.00 AS Numeric(5, 2)), NULL, NULL, NULL, NULL, N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 8013)
INSERT [dbo].[AvaliacaoObjetivoBebe] ([IdAvaliacaoObjetivoBebe], [dataRegisto], [Peso], [Altura], [pressaoArterial], [frequenciaCardiaca], [temperatura], [saturacaoOxigenio], [INR], [Perimetro], [IdTipoAleitamento], [nomeLeiteArtificial], [IdTipoParto], [partoDistocico], [epidoral], [episotomia], [reanimacaoFetal], [indiceAPGAR], [Fototerapia], [observacoes], [IdPaciente]) VALUES (3015, CAST(N'2020-06-13' AS Date), CAST(4.00 AS Numeric(5, 2)), 4, 3, 3, CAST(3.00 AS Numeric(5, 2)), 3, 3, 3, 1, N'ytuty', 2, N'Ventosa', N'Não', N'Não', N'Não', N'1º Minuto', N'Sim', N'tutu', 8013)
SET IDENTITY_INSERT [dbo].[AvaliacaoObjetivoBebe] OFF
GO
INSERT [dbo].[Cateterismo] ([IdAtitude], [IdPaciente], [data], [cateterismo], [observacoes]) VALUES (5, 8013, CAST(N'2020-06-11' AS Date), N'fgfg', N'fggfg')
INSERT [dbo].[Cateterismo] ([IdAtitude], [IdPaciente], [data], [cateterismo], [observacoes]) VALUES (5, 8013, CAST(N'2020-06-13' AS Date), N'cateterismo', N'obs')
GO
SET IDENTITY_INSERT [dbo].[Cirurgia] ON 

INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (1, N'Cirurgia 1', N'não sei.')
INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (2, N'Cirurgia 2', N'não sei')
INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (3, N'Cirurgia 3', N'não sei')
INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (4, N'Cirurgia 4', N'não sei')
INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (1002, N'Cirurgia 5', N'bbb')
INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (2002, N'Cirurgia 6', N'não sei.')
INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (2003, N'as', N'')
INSERT [dbo].[Cirurgia] ([IdCirurgia], [Nome], [Caracterizacao]) VALUES (2004, N'', N'')
SET IDENTITY_INSERT [dbo].[Cirurgia] OFF
GO
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (1, 1006, CAST(N'2020-03-29' AS Date), N' hjhjh')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (2, 1006, CAST(N'2020-03-29' AS Date), N' njkkjjjjkll')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (2, 4009, CAST(N'2020-03-29' AS Date), N'')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (3, 1, CAST(N'2020-03-12' AS Date), N'fdghjkl')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (3, 1006, CAST(N'2020-03-29' AS Date), N' ghjk')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (3, 4009, CAST(N'2020-03-29' AS Date), N'')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (3, 4016, CAST(N'2020-03-29' AS Date), N'dtyuh')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (4, 1006, CAST(N'2020-03-29' AS Date), N' ghjk')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (1002, 1006, CAST(N'2020-04-14' AS Date), N'ccbbcb')
INSERT [dbo].[CirurgiaPaciente] ([IdCirurgia], [IdPaciente], [data], [observacoes]) VALUES (2003, 4009, CAST(N'2020-03-29' AS Date), N'')
GO
INSERT [dbo].[ColheitadeSanguePrecoce] ([IdAtitude], [IdPaciente], [data], [idadeDias], [observacoes]) VALUES (11, 4016, CAST(N'2020-06-23' AS Date), 25, N'observações')
GO
INSERT [dbo].[ColheitaUrina] ([IdAtitude], [IdPaciente], [data], [exameSumario], [urocultura], [vinteQuantroHoras], [observacoes]) VALUES (12, 8013, CAST(N'2020-06-11' AS Date), N'Sim', N'Sim', N'Sim', N'dfdf')
INSERT [dbo].[ColheitaUrina] ([IdAtitude], [IdPaciente], [data], [exameSumario], [urocultura], [vinteQuantroHoras], [observacoes]) VALUES (12, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, N'Sim', NULL)
INSERT [dbo].[ColheitaUrina] ([IdAtitude], [IdPaciente], [data], [exameSumario], [urocultura], [vinteQuantroHoras], [observacoes]) VALUES (12, 8013, CAST(N'2020-06-13' AS Date), NULL, N'Sim', NULL, N'observações')
GO
INSERT [dbo].[ColocacaoDIU] ([IdAtitude], [IdPaciente], [data], [dataColocacaoDIU], [observacoes]) VALUES (14, 4020, CAST(N'2020-06-11' AS Date), CAST(N'2020-06-02' AS Date), NULL)
INSERT [dbo].[ColocacaoDIU] ([IdAtitude], [IdPaciente], [data], [dataColocacaoDIU], [observacoes]) VALUES (14, 8013, CAST(N'2020-06-11' AS Date), CAST(N'2020-06-11' AS Date), NULL)
INSERT [dbo].[ColocacaoDIU] ([IdAtitude], [IdPaciente], [data], [dataColocacaoDIU], [observacoes]) VALUES (14, 8013, CAST(N'2020-06-13' AS Date), CAST(N'2020-06-10' AS Date), N'dfdf')
GO
INSERT [dbo].[Colpocitologia] ([IdAtitude], [IdPaciente], [data], [dvm], [metodoContracetivoOral], [metodoContracetivoDIUData], [metodoContracetivoImplante], [metodoContracetivoImplanteData], [metodoContracetivoAnelVaginalData], [metodoContracetivoPreservativos], [metodoContracetivoIntramuscular], [metodoContracetivoInstramuscularData], [metodoContracetivoLaqTrompasData], [metodoCOntracetivoPessarioData], [observacoes]) VALUES (13, 8013, CAST(N'2020-06-11' AS Date), N'cvgf', N'pílula', NULL, NULL, NULL, CAST(N'2020-06-02' AS Date), N'Sim', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Colpocitologia] ([IdAtitude], [IdPaciente], [data], [dvm], [metodoContracetivoOral], [metodoContracetivoDIUData], [metodoContracetivoImplante], [metodoContracetivoImplanteData], [metodoContracetivoAnelVaginalData], [metodoContracetivoPreservativos], [metodoContracetivoIntramuscular], [metodoContracetivoInstramuscularData], [metodoContracetivoLaqTrompasData], [metodoCOntracetivoPessarioData], [observacoes]) VALUES (13, 8013, CAST(N'2020-06-13' AS Date), N'rtyyr', N'rtyry', CAST(N'2020-06-13' AS Date), N'rtyry', CAST(N'2020-06-13' AS Date), CAST(N'2020-06-13' AS Date), N'Sim', N'rtyr', CAST(N'2020-06-13' AS Date), CAST(N'2020-06-13' AS Date), CAST(N'2020-06-13' AS Date), N'rtyr')
GO
SET IDENTITY_INSERT [dbo].[Consulta] ON 

INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (1021, CAST(N'2020-04-08' AS Date), N' 17:56 ', N' fgf ', N' hfghg ', N' yuyi ', N' label2 ', 4030, 5005, CAST(2.00 AS Decimal(6, 2)), N' 17:56', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (2013, CAST(N'2020-04-08' AS Date), N' 19:44 ', N' fgtuy ', N' ytuyt ', N' yuiyu ', N' Dor Moderada ', 4010, 3003, CAST(40.00 AS Decimal(6, 2)), N' 19:44', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (2014, CAST(N'2020-04-08' AS Date), N' 19:46 ', N' fyty ', N' tyty ', N' tyt ', N' Dor Forte ', 4010, 3003, CAST(20.00 AS Decimal(6, 2)), N' 19:47', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (3013, CAST(N'2020-04-08' AS Date), N' 22:56 ', N' gfh ', N' fghf ', N' gh ', N' Dor Forte ', 1006, 3003, CAST(20.00 AS Decimal(6, 2)), N' 22:57', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (3014, CAST(N'2020-04-08' AS Date), N' 22:57 ', N' ghjgh ', N' ghjhg ', N' jhgjhg ', N' Dor Forte ', 1006, 3003, CAST(2.00 AS Decimal(6, 2)), N' 22:57', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (4013, CAST(N'2020-04-10' AS Date), N' 17:00 ', N' asd ', N' hgjyu ', N' uiuoui ', N' Dor Forte ', 1006, 3003, CAST(15.00 AS Decimal(6, 2)), N' 17:00', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (5013, CAST(N'2020-04-11' AS Date), N' 11:55 ', N' hkjh ', N' kjkj ', N' klj ', N' Dor Moderada ', 4009, 3003, CAST(15.00 AS Decimal(6, 2)), N' 11:55', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (9018, CAST(N'2020-04-14' AS Date), N'20:53', N'fghjk', N'fghjk', N'dfghjk', N'Sem Dor', 1006, 3003, CAST(15.00 AS Decimal(6, 2)), N'20:54', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (10013, CAST(N'2020-04-15' AS Date), N'21:58', N'sedrfgthlkj', N'gfdsdfghj', N'kjhgfdghj', N'Dor Ligeira', 1006, 3003, CAST(15.00 AS Decimal(6, 2)), N'21:58', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (11013, CAST(N'2020-04-18' AS Date), N'03:34', N'sdfdg', N'fdgh', N'df', N'Dor Moderada', 1006, 3003, CAST(15.00 AS Decimal(6, 2)), N'03:34', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (12013, CAST(N'2020-05-08' AS Date), N'22:31', N'sdf', N'dfgh', N'ertyu', N'Sem Dor', 11027, 3003, CAST(15.00 AS Decimal(6, 2)), N'22:31', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (13013, CAST(N'2020-05-11' AS Date), N'19:10', N'bla bla bla', N'bla bla bla', N'bla bla bla', N'Sem Dor', 1006, 3003, CAST(25.00 AS Decimal(6, 2)), N'19:11', N'bla bla bla')
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (14013, CAST(N'2020-05-13' AS Date), N'14:36', N'waertger', N'afe', N'dfgg', N'Dor Forte', 4011, 3003, CAST(25.00 AS Decimal(6, 2)), N'14:37', N'dfgdfgdf')
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (15013, CAST(N'2020-05-13' AS Date), N'21:50', N'dfghjk', N'dfghjkl', N'fghjk', N'Dor Moderada', 1006, 3003, CAST(25.00 AS Decimal(6, 2)), N'21:50', N'dfghjk')
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (16013, CAST(N'2020-05-15' AS Date), N'13:14', N'nkhj', N'kjljk', N'jkljk', N'Dor Ligeira', 1006, 3003, CAST(25.00 AS Decimal(6, 2)), N'13:14', N'ljkljkl')
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (16014, CAST(N'2020-05-15' AS Date), N'14:04', N'gfh', N'ghfgh', N'ghfh', N'Dor Máxima', 1006, 3003, CAST(25.00 AS Decimal(6, 2)), N'14:04', N'fghfh')
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (16015, CAST(N'2020-06-12' AS Date), N'16:46', N'o+', N'op+', N'op+o', N'Dor Ligeira', 8013, 3003, CAST(50.00 AS Decimal(6, 2)), N'16:46', N'op+o')
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (17015, CAST(N'2020-06-29' AS Date), N'17:08', NULL, NULL, NULL, N'Dor Ligeira', 1006, 3003, CAST(20.00 AS Decimal(6, 2)), N'17:08', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (17016, CAST(N'2020-06-29' AS Date), N'18:30', NULL, NULL, NULL, N'Dor Ligeira', 4016, 3003, CAST(25.00 AS Decimal(6, 2)), N'18:30', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (17017, CAST(N'2020-06-29' AS Date), N'18:30', NULL, NULL, NULL, N'Dor Ligeira', 4009, 3003, CAST(35.00 AS Decimal(6, 2)), N'18:30', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (17018, CAST(N'2020-06-29' AS Date), N'19:44', NULL, NULL, NULL, N'Dor Ligeira', 19034, 3003, CAST(55.50 AS Decimal(6, 2)), N'19:44', NULL)
INSERT [dbo].[Consulta] ([IdConsulta], [dataConsulta], [horaInicioConsulta], [historiaAtual], [sintomatologia], [sinais], [escalaDor], [idPaciente], [idEnfermeiro], [valorConsulta], [horaFimConsulta], [diagnostico]) VALUES (18016, CAST(N'2020-06-29' AS Date), N'20:14', NULL, NULL, NULL, NULL, 4014, 3003, CAST(25.00 AS Decimal(6, 2)), N'20:14', NULL)
SET IDENTITY_INSERT [dbo].[Consulta] OFF
GO
SET IDENTITY_INSERT [dbo].[ConsultaProdutoStock] ON 

INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (1, 1, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (2, 3, 5, N'ui89')
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (3, 2006, 6, N'ui89')
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (4, 2, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5, 1003, 6, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (1002, 1, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (2002, 4, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (3002, 2, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (3003, 2, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (3004, 1, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (4002, 3, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (4003, 3, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5002, 2, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5003, 2, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5004, 1008, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5005, 1003, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5006, 2, 5, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5007, 1003, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5008, 2, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5009, 1008, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (5010, 2, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6002, 1, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6003, 1008, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6004, 1, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6005, 2, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6006, 2, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6007, 1004, 6, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6008, 1003, 4, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6009, 4, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6010, 4, 6, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6011, 1, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6012, 3, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6013, 1, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6014, 3, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6015, 1002, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6016, 2, 1, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6017, 1002, 2, NULL)
INSERT [dbo].[ConsultaProdutoStock] ([IdConsultaProdutoStock], [IdProdutoStock], [quantidadeUsada], [observacoes]) VALUES (6018, 2, 4, NULL)
SET IDENTITY_INSERT [dbo].[ConsultaProdutoStock] OFF
GO
INSERT [dbo].[Crioterapia] ([IdAtitude], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (15, 4016, CAST(N'2020-06-30' AS Date), N'mão', N'observações')
GO
INSERT [dbo].[Desbridamento] ([IdAtitude], [IdPaciente], [data], [antolitico], [enzimatico], [cirurgico], [observacoes]) VALUES (17, 8013, CAST(N'2020-06-11' AS Date), N'drt', N'rtyt', N'ytuty', N'ytutyu')
INSERT [dbo].[Desbridamento] ([IdAtitude], [IdPaciente], [data], [antolitico], [enzimatico], [cirurgico], [observacoes]) VALUES (17, 8013, CAST(N'2020-06-12' AS Date), N'u89', N'789789', N'789uu', N'uiy')
INSERT [dbo].[Desbridamento] ([IdAtitude], [IdPaciente], [data], [antolitico], [enzimatico], [cirurgico], [observacoes]) VALUES (17, 8013, CAST(N'2020-06-13' AS Date), NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Despesa] ON 

INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (9, CAST(N'2020-05-21' AS Date), CAST(19.00 AS Numeric(6, 2)), NULL, 1004, 3007)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (10, CAST(N'2020-04-13' AS Date), CAST(5.00 AS Numeric(6, 2)), NULL, 1002, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (11, CAST(N'2020-05-18' AS Date), CAST(25.00 AS Numeric(6, 2)), NULL, 1004, 1019)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (12, CAST(N'2020-05-19' AS Date), CAST(50.00 AS Numeric(6, 2)), NULL, 1002, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (13, CAST(N'2020-05-01' AS Date), CAST(50.00 AS Numeric(6, 2)), NULL, 1002, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (15, CAST(N'2020-06-01' AS Date), CAST(25.00 AS Numeric(6, 2)), NULL, 1002, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (1003, CAST(N'2020-05-19' AS Date), CAST(70.00 AS Numeric(6, 2)), NULL, 1003, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (1004, CAST(N'2020-04-15' AS Date), CAST(75.00 AS Numeric(6, 2)), NULL, 1003, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (1005, CAST(N'2020-04-15' AS Date), CAST(55.00 AS Numeric(6, 2)), NULL, 1002, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (2003, CAST(N'2020-05-21' AS Date), CAST(15.00 AS Numeric(6, 2)), NULL, 1004, 3010)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (3003, CAST(N'2020-04-15' AS Date), CAST(0.00 AS Numeric(6, 2)), NULL, 1004, 3009)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (4003, CAST(N'2020-06-26' AS Date), CAST(6.00 AS Numeric(6, 2)), N'yut', 1004, 8010)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (4004, CAST(N'2020-06-26' AS Date), CAST(0.00 AS Numeric(6, 2)), NULL, 1002, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (5003, CAST(N'2020-06-26' AS Date), CAST(2.00 AS Numeric(6, 2)), NULL, 1002, NULL)
INSERT [dbo].[Despesa] ([IdDespesa], [data], [valor], [observacoes], [idTipoDespesa], [idEncomenda]) VALUES (6003, CAST(N'2020-06-29' AS Date), CAST(3.00 AS Numeric(6, 2)), NULL, 1004, 9009)
SET IDENTITY_INSERT [dbo].[Despesa] OFF
GO
SET IDENTITY_INSERT [dbo].[Doenca] ON 

INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (1, N'Doenca 1 ', N'tosse, febre, arrepios, diarreia')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (2, N'Doenca 2 ', N' sintoma 1, sintoma 2, sintoma 3, sintoma 4')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (3, N'Doença 3 ', N' sintoma 1, sintoma 2, sintoma 3, sintoma 4, sintoma 5, sintoma 6, sintoma 7, etc.')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (1002, N'Doença 4 ', N' asdfghjklç')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (1003, N'Doença 5 ', N' Sintoma 1, Sintoma 2, Sintoma 3, Sintoma 4, Sintoma 5, etc')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (1004, N'Doença 6 ', N' sintoma a')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (1005, N'Doença 7 ', N' sintoma 1, sintoma 2, etc')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (1006, N'Doença 10 ', N'  sintoma a, sintoma b, sintoma c, etc.')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (2002, N'Doença 11', N'sintoma a, sintoma b, sintoma c, etc.')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (3002, N'Doença 9', N'sintoma a, sintoma b, sintoma c, etc.')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (4002, N'Doença', N' hihih')
INSERT [dbo].[Doenca] ([IdDoenca], [Nome], [Sintomas]) VALUES (5002, N'dfghjk', N'frghjkl''"')
SET IDENTITY_INSERT [dbo].[Doenca] OFF
GO
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1, 1006, CAST(N'2020-03-29' AS Date), N' nada')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1, 4009, CAST(N'2020-11-04' AS Date), N'ghytu')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (2, 1006, CAST(N'2020-03-29' AS Date), N' sdfsdfsdf')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (2, 4009, CAST(N'2020-11-04' AS Date), N'ghjuyiyi')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (3, 1006, CAST(N'2020-03-29' AS Date), N' xdfghjklçº')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1002, 1006, CAST(N'2020-03-29' AS Date), N' sdfghjklçº')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1003, 1006, CAST(N'2020-03-29' AS Date), N'fhnvgjbj')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1003, 4016, CAST(N'2020-04-14' AS Date), N'xcvbn')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1004, 1006, CAST(N'2020-03-29' AS Date), N' milhares')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1006, 1006, CAST(N'2020-03-29' AS Date), N' rtyhjuklçº')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (1006, 1006, CAST(N'2020-04-14' AS Date), N'zchf')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (2002, 1006, CAST(N'2020-03-29' AS Date), N' dfghj')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (4002, 1006, CAST(N'2020-03-29' AS Date), N'defghjm,')
INSERT [dbo].[DoencaPaciente] ([IdDoenca], [IdPaciente], [data], [observacoes]) VALUES (4002, 1006, CAST(N'2020-04-09' AS Date), N'jhk')
GO
SET IDENTITY_INSERT [dbo].[DopletFetal] ON 

INSERT [dbo].[DopletFetal] ([IdDoplerFetal], [IdPaciente], [ig], [dppData], [dppcData], [primeiraEcografia], [escalaDor], [observacoes]) VALUES (1, 8013, 456, CAST(N'2020-06-12' AS Date), CAST(N'2020-06-09' AS Date), CAST(N'2020-06-02' AS Date), NULL, N'op+ppo')
INSERT [dbo].[DopletFetal] ([IdDoplerFetal], [IdPaciente], [ig], [dppData], [dppcData], [primeiraEcografia], [escalaDor], [observacoes]) VALUES (2, 8013, 54645, CAST(N'2020-06-12' AS Date), NULL, NULL, N'Dor Moderada', N'nada')
INSERT [dbo].[DopletFetal] ([IdDoplerFetal], [IdPaciente], [ig], [dppData], [dppcData], [primeiraEcografia], [escalaDor], [observacoes]) VALUES (3, 8013, 6, NULL, CAST(N'2020-06-12' AS Date), NULL, N'Dor Forte', N'ujii')
INSERT [dbo].[DopletFetal] ([IdDoplerFetal], [IdPaciente], [ig], [dppData], [dppcData], [primeiraEcografia], [escalaDor], [observacoes]) VALUES (4, 8013, 65, NULL, NULL, CAST(N'2020-06-12' AS Date), N'Dor Moderada', N'uiy')
INSERT [dbo].[DopletFetal] ([IdDoplerFetal], [IdPaciente], [ig], [dppData], [dppcData], [primeiraEcografia], [escalaDor], [observacoes]) VALUES (5, 8013, 56, NULL, NULL, NULL, N'Dor Moderada', N'oipio')
SET IDENTITY_INSERT [dbo].[DopletFetal] OFF
GO
INSERT [dbo].[DrenagemLocas] ([IdAtitude], [IdPaciente], [data], [drenagemLocas], [observacoes]) VALUES (16, 8013, CAST(N'2020-06-11' AS Date), N'dfsf', N'dfsdf')
INSERT [dbo].[DrenagemLocas] ([IdAtitude], [IdPaciente], [data], [drenagemLocas], [observacoes]) VALUES (16, 8013, CAST(N'2020-06-12' AS Date), N'cfgg', N'gfg')
INSERT [dbo].[DrenagemLocas] ([IdAtitude], [IdPaciente], [data], [drenagemLocas], [observacoes]) VALUES (16, 8013, CAST(N'2020-06-13' AS Date), N'Drenagem', N'obs')
GO
SET IDENTITY_INSERT [dbo].[Encomenda] ON 

INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (1, 2, N'F.021', CAST(N'2020-04-17' AS Date), CAST(N'2020-05-07' AS Date), CAST(N'2020-04-18' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (5, 2, N'F.022', CAST(N'2020-04-18' AS Date), CAST(N'2020-04-19' AS Date), CAST(N'2020-04-20' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (12, 1, N'F.023', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-20' AS Date), CAST(N'2020-04-17' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (123, 2, N'F.024', CAST(N'2020-04-16' AS Date), CAST(N'2020-04-18' AS Date), CAST(N'2020-04-21' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (124, 2, N'F.025', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-20' AS Date), CAST(N'2020-04-17' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (125, 2, N'F.026', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-22' AS Date), CAST(N'2020-04-17' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (126, 3, N'F.027', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-24' AS Date), CAST(N'2020-04-17' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (127, 3, N'F.028', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-24' AS Date), CAST(N'2020-04-17' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (128, 3, N'F.029', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-17' AS Date), CAST(N'2020-04-19' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (129, 2, N'F.030', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-24' AS Date), CAST(N'2020-04-22' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (130, 3, N'F.031', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-18' AS Date), CAST(N'2020-04-22' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (131, 2, N'F.032', CAST(N'2020-04-17' AS Date), CAST(N'2020-04-17' AS Date), CAST(N'2020-06-29' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (300, 3, N'F.034', CAST(N'2020-05-18' AS Date), CAST(N'2020-05-29' AS Date), NULL, 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (1003, 2, N'F.038', CAST(N'2020-04-16' AS Date), CAST(N'2020-04-20' AS Date), CAST(N'2020-04-20' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (1019, 2, N'f70', CAST(N'2020-05-19' AS Date), CAST(N'2020-05-19' AS Date), NULL, 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3007, 4, N'F.040', CAST(N'2020-05-20' AS Date), CAST(N'2020-05-25' AS Date), NULL, 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3009, 4, N'f45', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-26' AS Date), NULL, 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3010, 3, N'f46', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-26' AS Date), NULL, 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3014, 2, N'47', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-21' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3015, 2, N'ed', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-21' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3016, 3, N'fghjk', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-21' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3017, 3, N'ert', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-21' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3018, 3, N'cfvgbhnjmk,l', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-21' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3019, 4, N'gdfghjklçº', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-21' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (3020, 3, N'cghnjmk,lç.º', CAST(N'2020-05-21' AS Date), CAST(N'2020-05-21' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (4008, 2, N'f58', CAST(N'2020-05-24' AS Date), CAST(N'2020-05-28' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (4009, 3, N'hvbnjmk', CAST(N'2020-05-24' AS Date), CAST(N'2020-05-24' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (5008, 2, N'250', CAST(N'2020-05-30' AS Date), CAST(N'2020-06-01' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (6008, 2, N'300', CAST(N'2020-05-30' AS Date), CAST(N'2020-05-30' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (6009, 3, N'301', CAST(N'2020-05-30' AS Date), CAST(N'2020-05-30' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (6011, 3, N'302', CAST(N'2020-05-30' AS Date), CAST(N'2020-05-30' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (8008, 2, N'ghyt', CAST(N'2020-05-31' AS Date), CAST(N'2020-05-31' AS Date), CAST(N'2020-06-02' AS Date), 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (8010, 2, N'500', CAST(N'2020-05-31' AS Date), CAST(N'2020-05-31' AS Date), CAST(N'2020-06-02' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (9008, 2, N'600', CAST(N'2020-05-31' AS Date), CAST(N'2020-06-01' AS Date), CAST(N'2020-06-02' AS Date), 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (9009, 2, N'650', CAST(N'2020-05-31' AS Date), CAST(N'2020-05-31' AS Date), CAST(N'2020-05-31' AS Date), 1)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (9010, 2, N'520', CAST(N'2020-06-01' AS Date), CAST(N'2020-06-01' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (10008, 2, N'5005', CAST(N'2020-06-02' AS Date), CAST(N'2020-06-02' AS Date), NULL, 0)
INSERT [dbo].[Encomenda] ([IdEncomenda], [idFornecedor], [Nfatura], [dataRegistoEncomenda], [dataEntregaPrevista], [dataEntregaReal], [pago]) VALUES (11008, 2, N'dgfg', CAST(N'2020-07-01' AS Date), CAST(N'2020-07-01' AS Date), NULL, 0)
SET IDENTITY_INSERT [dbo].[Encomenda] OFF
GO
SET IDENTITY_INSERT [dbo].[Enfermeiro] ON 

INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (3002, N'Ana Maria Gonçalves', N'Enfermeiro', CAST(102520369 AS Numeric(9, 0)), CAST(N'2020-02-03' AS Date), N'Ana', N'46B2AFF98E3F28137DE297451F42A5A8', N'ana@mail.pt', 0, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (3003, N'Daniela Maria J. Marques', N'Enfermeira', CAST(916745898 AS Numeric(9, 0)), CAST(N'1985-12-25' AS Date), N'Daniela', N'CF93B44188BDBF1DD5DC613434E3C4BB', N'daniela@gmail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (3004, N'Jenny', N'enfermeira', CAST(12304568 AS Numeric(9, 0)), CAST(N'2020-11-03' AS Date), N'Jenny', N'38C948A127077FFD26D69A20F13977E0', N'jenny@mail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (4003, N'Pessoa Bu', N'Enfermeiro', CAST(222555666 AS Numeric(9, 0)), CAST(N'2020-12-03' AS Date), N'Bu', N'91DCCC400F7BA44ADC6FE4B79B80D25F', N'bu@mail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (4004, N'Miau', N'Miau', CAST(159874632 AS Numeric(9, 0)), CAST(N'2020-10-03' AS Date), N'Miau2', N'38C948A127077FFD26D69A20F13977E0', N'miau@mail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (4006, N'asdfghj', N'dfgh', CAST(123654789 AS Numeric(9, 0)), CAST(N'2020-01-03' AS Date), N'Username', N'38C948A127077FFD26D69A20F13977E0', N'ad@mail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (5005, N'Andreia', N'Enfermeira', CAST(912036548 AS Numeric(9, 0)), CAST(N'2020-02-03' AS Date), N'AndreiaF16', N'241EC87C430D0E64ECBE21D894C5561C', N'email@gmail.com', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (5006, N'Enfermeiro', N'Enfermeiro', CAST(520145632 AS Numeric(9, 0)), CAST(N'2020-03-02' AS Date), N'Enfermeiro2', N'9C8D648568CE6CB285BE97664A591D1E', N'enfermeiro@mail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (6006, N'sdfghjk', N'azsdfghjkl', CAST(243876736 AS Numeric(9, 0)), CAST(N'2020-03-29' AS Date), N'User', N'5A30C9609B52FE348FB6925896E061DE', N'rtyut@mail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (6008, N'uyiyui', N'tuytuyt', CAST(256787456 AS Numeric(9, 0)), CAST(N'2020-03-02' AS Date), N'anaa', N'5A30C9609B52FE348FB6925896E061DE', N'yuiyu@mail.pt', 1, 0)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (7007, N'Maria Joaquina', N'Enfermeiro', CAST(910256888 AS Numeric(9, 0)), CAST(N'2020-03-12' AS Date), N'Anana', N'F6B70DF308E3B4F32CBEBF572CAA5535', N'ryetet@mail.pt', 1, 1)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (9007, N'Patricia Moreira', N'Enfeimeira', CAST(910254623 AS Numeric(9, 0)), CAST(N'2020-04-03' AS Date), N'UserPatricia', N'F6B70DF308E3B4F32CBEBF572CAA5535', N'annefernandes1994@gmail.com', 1, 1)
INSERT [dbo].[Enfermeiro] ([IdEnfermeiro], [nome], [funcao], [contacto], [dataNascimento], [username], [password], [email], [permissao], [passwordDefault]) VALUES (9008, N'asdfghj', N'dfghjk', CAST(215487654 AS Numeric(9, 0)), CAST(N'2020-06-02' AS Date), N'kjhfdhtry', N'F6B70DF308E3B4F32CBEBF572CAA5535', N'erty@mail.pt', 1, 1)
SET IDENTITY_INSERT [dbo].[Enfermeiro] OFF
GO
INSERT [dbo].[ENG] ([IdAtitude], [IdPaciente], [data], [numeroENG], [dataENG], [observacoes]) VALUES (19, 8013, CAST(N'2020-06-11' AS Date), 45, CAST(N'2020-06-09' AS Date), NULL)
INSERT [dbo].[ENG] ([IdAtitude], [IdPaciente], [data], [numeroENG], [dataENG], [observacoes]) VALUES (19, 8013, CAST(N'2020-06-13' AS Date), 456, CAST(N'2020-06-10' AS Date), N'dfgf')
GO
SET IDENTITY_INSERT [dbo].[Espirometria] ON 

INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-12' AS Date), N'gyu', N'uty', NULL, NULL, N'Profunda', N'Abdominal', NULL, N'Mista', N'Dor Moderada', N'yu78')
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-12' AS Date), N'yu', N'uiu', 456, N'Superficial', N'Profunda', N'Abdominal', N'Torácica', NULL, N'Dor Ligeira', N'ytuytu')
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (4, 8013, CAST(N'2020-06-12' AS Date), N'oipio', N'opio', 56478, N'Superficial', N'Profunda', N'Abdominal', N'Torácica', N'Mista', N'Dor Ligeira', N'yiyu')
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (5, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (6, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (7, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, 4545, NULL, NULL, NULL, NULL, NULL, N'Dor Moderada', NULL)
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (8, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, 45543, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (9, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Dor Muito Forte', NULL)
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (10, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, 4543, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Espirometria] ([IdEspirometria], [IdPaciente], [data], [fev], [fvc], [fr], [caracteristicaSuperficial], [caracteristicaProfunda], [caracteristicaAdbominal], [caracteristicaToracica], [caracteristicaMista], [escalaDor], [observacoes]) VALUES (11, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Dor Moderada', NULL)
SET IDENTITY_INSERT [dbo].[Espirometria] OFF
GO
INSERT [dbo].[Exame] ([idPaciente], [idTipoExame], [data], [designacao], [observacoes]) VALUES (1006, 1, CAST(N'2020-03-29' AS Date), N' fghf ', N' hfghfg')
INSERT [dbo].[Exame] ([idPaciente], [idTipoExame], [data], [designacao], [observacoes]) VALUES (1006, 1, CAST(N'2020-04-14' AS Date), N'dfgh', N'jhgfd')
INSERT [dbo].[Exame] ([idPaciente], [idTipoExame], [data], [designacao], [observacoes]) VALUES (1006, 2, CAST(N'2020-03-29' AS Date), N' hjhk ', N' khjk')
INSERT [dbo].[Exame] ([idPaciente], [idTipoExame], [data], [designacao], [observacoes]) VALUES (1006, 2, CAST(N'2020-04-14' AS Date), N'xn', N'jhgfds')
INSERT [dbo].[Exame] ([idPaciente], [idTipoExame], [data], [designacao], [observacoes]) VALUES (1006, 1002, CAST(N'2020-03-29' AS Date), N' hjhk ', N' jljio')
INSERT [dbo].[Exame] ([idPaciente], [idTipoExame], [data], [designacao], [observacoes]) VALUES (4016, 2002, CAST(N'2020-03-29' AS Date), N'gfgh', N'ljkjfg')
GO
INSERT [dbo].[Flebografia] ([IdAtitude], [IdPaciente], [data], [flebografia], [observacoes]) VALUES (20, 8013, CAST(N'2020-06-11' AS Date), N'fgfh', N'hfghfg')
INSERT [dbo].[Flebografia] ([IdAtitude], [IdPaciente], [data], [flebografia], [observacoes]) VALUES (20, 8013, CAST(N'2020-06-13' AS Date), N'dfg', N'fgfg')
GO
SET IDENTITY_INSERT [dbo].[Fornecedor] ON 

INSERT [dbo].[Fornecedor] ([IdFornecedor], [nif], [nome], [contacto], [email], [observacoes], [rua], [numeroMorada], [andarPiso], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao]) VALUES (1, 123654526, N'Fornecedor Um', 111225486, N'mail@mail.pt', N'Fornecedor de produto 1, produto 2, produto 3, etc...', N'Morada 1', 20, N'1º andar, esquerdo', N'Lisboa', NULL, N'2405', N'075', NULL)
INSERT [dbo].[Fornecedor] ([IdFornecedor], [nif], [nome], [contacto], [email], [observacoes], [rua], [numeroMorada], [andarPiso], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao]) VALUES (2, 159874526, N'Fátima Maria Pereira', 111222222, N'fornecedorDois@mail.pt', NULL, N'Rua das Flores', 14, N'RC ESQ', N'Bairro da Pedra', N'Mato Cheirinhos', N'2785', N'174', N'SÃO DOMINGOS DE RANA')
INSERT [dbo].[Fornecedor] ([IdFornecedor], [nif], [nome], [contacto], [email], [observacoes], [rua], [numeroMorada], [andarPiso], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao]) VALUES (3, 111548451, N'Fornecedor sfsdfdsf', 154867545, N'fornecedorf@mail.pt', N'dsfsdfdg', N'Morada 3', 7, NULL, N'Porto', NULL, N'2100', N'200', NULL)
INSERT [dbo].[Fornecedor] ([IdFornecedor], [nif], [nome], [contacto], [email], [observacoes], [rua], [numeroMorada], [andarPiso], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao]) VALUES (4, 111548451, N'João Pereira', 154867545, N'fornecedorf@mail.pt', NULL, N'Rua da Avenida 1º de Maio', NULL, NULL, N'Leiria', NULL, N'2403', N'300', NULL)
INSERT [dbo].[Fornecedor] ([IdFornecedor], [nif], [nome], [contacto], [email], [observacoes], [rua], [numeroMorada], [andarPiso], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao]) VALUES (5, 245120124, N'ghjk', 241250461, N'dfghj@mail.pt', NULL, N'sadasdsad', 25, N'trft2541', N'lkjhygfsd', N'jhgfds', N'1543', N'021', N'SFDGHJ')
SET IDENTITY_INSERT [dbo].[Fornecedor] OFF
GO
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 1006, CAST(N'2020-07-01' AS Date), CAST(N'2020-07-01' AS Date), CAST(N'2020-07-24' AS Date), NULL)
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 4011, CAST(N'2020-07-01' AS Date), CAST(N'2020-07-01' AS Date), CAST(N'2020-07-01' AS Date), NULL)
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 4020, CAST(N'2020-06-11' AS Date), CAST(N'2020-06-02' AS Date), CAST(N'2020-06-11' AS Date), NULL)
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 8013, CAST(N'2020-06-11' AS Date), CAST(N'2020-06-01' AS Date), CAST(N'2020-06-10' AS Date), NULL)
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 8013, CAST(N'2020-06-13' AS Date), CAST(N'2020-06-09' AS Date), CAST(N'2020-06-10' AS Date), N'sdad')
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 8013, CAST(N'2020-06-28' AS Date), CAST(N'2020-06-21' AS Date), CAST(N'2020-07-02' AS Date), NULL)
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 11027, CAST(N'2020-07-01' AS Date), CAST(N'2020-07-01' AS Date), CAST(N'2020-07-24' AS Date), NULL)
INSERT [dbo].[ImplanteContracetivo] ([IdAtitude], [IdPaciente], [data], [dataColocacao], [dataRetirada], [observacoes]) VALUES (22, 19032, CAST(N'2020-07-01' AS Date), CAST(N'2020-07-01' AS Date), CAST(N'2020-07-24' AS Date), NULL)
GO
INSERT [dbo].[Inalacoes] ([IdAtitude], [IdPaciente], [data], [O2], [aerossol], [inaladores], [observacoes]) VALUES (21, 8013, CAST(N'2020-06-11' AS Date), N'dg', N'tuytu', N'rtrty', N'tyuty')
INSERT [dbo].[Inalacoes] ([IdAtitude], [IdPaciente], [data], [O2], [aerossol], [inaladores], [observacoes]) VALUES (21, 8013, CAST(N'2020-06-13' AS Date), N'tyt', N'tyutyu', N'yut', N'tyutu')
GO
INSERT [dbo].[LavagemAuricular] ([IdAtitude], [IdPaciente], [data], [ouvidoDireito], [ouvidoEsquerdo], [ambos], [observacoes]) VALUES (23, 8013, CAST(N'2020-06-11' AS Date), NULL, N'Sim', NULL, N'xcv')
INSERT [dbo].[LavagemAuricular] ([IdAtitude], [IdPaciente], [data], [ouvidoDireito], [ouvidoEsquerdo], [ambos], [observacoes]) VALUES (23, 8013, CAST(N'2020-06-13' AS Date), NULL, NULL, N'Sim', N'gyut')
GO
INSERT [dbo].[LavagemOcular] ([IdAtitude], [IdPaciente], [data], [olhoDireito], [olhoEsquerdo], [ambos], [observacoes]) VALUES (25, 8013, CAST(N'2020-06-11' AS Date), NULL, N'Sim', NULL, N'serwr')
INSERT [dbo].[LavagemOcular] ([IdAtitude], [IdPaciente], [data], [olhoDireito], [olhoEsquerdo], [ambos], [observacoes]) VALUES (25, 8013, CAST(N'2020-06-13' AS Date), NULL, NULL, NULL, N'cera')
GO
INSERT [dbo].[LavagemVesical] ([IdAtitude], [IdPaciente], [data], [lavagemVesical], [observacoes]) VALUES (26, 8013, CAST(N'2020-06-02' AS Date), N'tytu', N'tyutyu')
INSERT [dbo].[LavagemVesical] ([IdAtitude], [IdPaciente], [data], [lavagemVesical], [observacoes]) VALUES (26, 8013, CAST(N'2020-06-11' AS Date), N'tytr', N'rtyrt')
INSERT [dbo].[LavagemVesical] ([IdAtitude], [IdPaciente], [data], [lavagemVesical], [observacoes]) VALUES (26, 8013, CAST(N'2020-06-13' AS Date), N'lavagem', N'obs')
GO
SET IDENTITY_INSERT [dbo].[LinhaEncomenda] ON 

INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (1, 3, 2, 127)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (2, 2, 2, 127)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (3, 3, 4, 127)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (4, 5, 1, 127)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (5, 2, 2, 130)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (6, 2, 1004, 131)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (7, 5, 2, 5)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (8, 4, 1, 5)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (9, 1, 2005, 300)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (10, 2, 3, 300)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (11, 4, 2006, 300)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (2013, 5, 2, 1019)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (2014, 2, 1008, 1019)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (3011, 5, 4, 3007)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (3012, 5, 3005, 3009)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (3013, 6, 4, 3009)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (3014, 1, 3006, 3010)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (3015, 2, 2006, 3010)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (3016, 50, 1004, 3010)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (4011, 2, 2, 8008)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (4012, 2, 2, 8010)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (5011, 4, 2, 9008)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (5012, 2, 2, 9009)
INSERT [dbo].[LinhaEncomenda] ([IdLinhaEncomenda], [quantidade], [idProdutoStock], [idEncomenda]) VALUES (6011, 5, 2, 10008)
SET IDENTITY_INSERT [dbo].[LinhaEncomenda] OFF
GO
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-03' AS Date), N'fdgdg
	dfgdfgdfg
	xdfdfdfg
	sdfsdfsdf
	ddreterte
	dfgdfgdfg
	
	', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-10' AS Date), N'ghhg, ghgh, jgghj', N'ghg')
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-11' AS Date), N'vhghg
	
	', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-16' AS Date), N'mão, pé, dedo', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-27' AS Date), N'hgjghj
	jkljkljo
	uiououo
	oipip
	
	', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-28' AS Date), N'mao, pe,', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-27' AS Date), N'', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-28' AS Date), N'dedo, mão, pé, ', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-17' AS Date), N'dedo
	mão
	pé
	
	', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-27' AS Date), N'', NULL)
INSERT [dbo].[LocalizacaoDor] ([IdTratamentoMaosPes], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-28' AS Date), N', fhfh, fhfhfgh, fghfghgfh, fghfghfgh, fghfghfg, ', NULL)
GO
SET IDENTITY_INSERT [dbo].[LocalizacaoDorConsulta] ON 

INSERT [dbo].[LocalizacaoDorConsulta] ([IdLocalizacaoDor], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-27' AS Date), N'reter
	ertert
	ghytutyu
	
	', NULL)
INSERT [dbo].[LocalizacaoDorConsulta] ([IdLocalizacaoDor], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-25' AS Date), N'
	
	', NULL)
INSERT [dbo].[LocalizacaoDorConsulta] ([IdLocalizacaoDor], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-02' AS Date), N'
	', NULL)
INSERT [dbo].[LocalizacaoDorConsulta] ([IdLocalizacaoDor], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (4, 8013, CAST(N'2020-06-03' AS Date), N'
	', NULL)
INSERT [dbo].[LocalizacaoDorConsulta] ([IdLocalizacaoDor], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (5, 8013, CAST(N'2020-06-16' AS Date), N'dedo
	
	', NULL)
INSERT [dbo].[LocalizacaoDorConsulta] ([IdLocalizacaoDor], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1002, 8013, CAST(N'2020-06-29' AS Date), N'sfgd, fdgdg', N'yutut')
INSERT [dbo].[LocalizacaoDorConsulta] ([IdLocalizacaoDor], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (2002, 4016, CAST(N'2020-06-30' AS Date), N'fgffh, iuouiouio', NULL)
SET IDENTITY_INSERT [dbo].[LocalizacaoDorConsulta] OFF
GO
SET IDENTITY_INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ON 

INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-27' AS Date), N'dfdg
	
	', NULL)
INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-19' AS Date), N'gfhfgh
	fghfghfgh
	fghfhf
	
	', NULL)
INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-19' AS Date), N'gfhfh
	fghfgh
	fghfghfgh
	
	', NULL)
INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1002, 8013, CAST(N'2020-06-28' AS Date), N'dedo
	
	', N'nada...')
INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1003, 8013, CAST(N'2020-06-17' AS Date), N'rtyrty, tryryrty, rtyry', N'ftyryy')
INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1004, 8013, CAST(N'2020-06-02' AS Date), N'perna, rabo', N'ola')
INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1005, 8013, CAST(N'2020-06-29' AS Date), N'hghg, ghgh, jkkjk', N'fgh')
SET IDENTITY_INSERT [dbo].[LocalizacaoDorDopplerArterialVenoso] OFF
GO
SET IDENTITY_INSERT [dbo].[LocalizacaoDorDopplerFetal] ON 

INSERT [dbo].[LocalizacaoDorDopplerFetal] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-29' AS Date), N'mao, pe', NULL)
SET IDENTITY_INSERT [dbo].[LocalizacaoDorDopplerFetal] OFF
GO
SET IDENTITY_INSERT [dbo].[LocalizacaoDorEspirometria] ON 

INSERT [dbo].[LocalizacaoDorEspirometria] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-29' AS Date), N'dedo', N'obs')
INSERT [dbo].[LocalizacaoDorEspirometria] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-29' AS Date), N'dbfd', NULL)
INSERT [dbo].[LocalizacaoDorEspirometria] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-29' AS Date), N'fryt, ghghjghj', NULL)
SET IDENTITY_INSERT [dbo].[LocalizacaoDorEspirometria] OFF
GO
SET IDENTITY_INSERT [dbo].[LocalizacaoDorVacinacao] ON 

INSERT [dbo].[LocalizacaoDorVacinacao] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-10' AS Date), N'aqui, outra', N'Nda')
INSERT [dbo].[LocalizacaoDorVacinacao] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-29' AS Date), N'rytyr', N'drtrt')
INSERT [dbo].[LocalizacaoDorVacinacao] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1002, 1006, CAST(N'2020-06-29' AS Date), N'mão', N'obs')
INSERT [dbo].[LocalizacaoDorVacinacao] ([IdTratamento], [IdPaciente], [data], [localizacao], [observacoes]) VALUES (1003, 8013, CAST(N'2020-06-24' AS Date), N'dedo, corpo', N'hj')
SET IDENTITY_INSERT [dbo].[LocalizacaoDorVacinacao] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicacao] ON 

INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (1, N'xgdfg', N'Sim', N'Não', N'Não', N'Não', N'Não', N'Sim', 4009, CAST(N'2020-06-10' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (2, N'fgfh', N'Não', N'Não', N'Não', N'Não', N'Sim', N'Sim', 4009, CAST(N'2020-06-10' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (1002, N'tyry', NULL, N'Sim', NULL, NULL, N'Sim', N'Sim', 8013, CAST(N'2020-06-27' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (2002, N'Med 1', N'Sim', N'Sim', N'Sim', N'Sim', N'Sim', N'Sim', 8013, CAST(N'2020-06-29' AS Date), N'meio comprimido', N'1', N'0', N'0', N'0', N'0', NULL)
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (2003, N'med', N'Sim', NULL, NULL, NULL, NULL, NULL, 8013, CAST(N'2020-06-10' AS Date), N'2', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (3002, N'frtry', N'Sim', NULL, NULL, NULL, NULL, NULL, 4016, CAST(N'2020-06-30' AS Date), N'po', NULL, NULL, NULL, NULL, NULL, N'tryry')
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (4002, N'df', N'Sim', NULL, NULL, NULL, NULL, NULL, 4011, CAST(N'2020-07-01' AS Date), N'5', NULL, NULL, NULL, NULL, NULL, N'dfghj')
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (4003, N'j', NULL, N'Sim', NULL, NULL, NULL, NULL, 4011, CAST(N'2020-07-01' AS Date), N'5', N'meio quantidade', NULL, NULL, NULL, NULL, N'dfghj')
INSERT [dbo].[Medicacao] ([IdMedicacao], [medicamentos], [jejum], [pequenoAlmoco], [almoco], [lanche], [jantar], [deitar], [IdPaciente], [data], [quantidadeJejum], [quantidadePequenoAlmoco], [quantidadeAlmoco], [quantidadeLanche], [quantidadeJantar], [quantidadeDeitar], [observacoes]) VALUES (5002, N'fghty', N'Sim', NULL, NULL, NULL, NULL, NULL, 4011, CAST(N'2020-07-02' AS Date), N'1', NULL, NULL, NULL, NULL, NULL, N'ryry')
SET IDENTITY_INSERT [dbo].[Medicacao] OFF
GO
SET IDENTITY_INSERT [dbo].[MetodoContracetivo] ON 

INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (1, N'Pílula 21 cp + 7 dias pausa', N'tomar 21 dias seguidos + 7 dias de pausa')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (2, N'Pilula 24 cp + 4 dias placebo', N'tomar 24 dias seguidos + 4 dias de pausa')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (3, N'Pilula 28 cp sem pausa', N'este tipo de pilula é tomada sempre, não tem pausa.')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (4, N'Implante de progestativo - Implanon', N'')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (5, N'Progestativo Injectável - Depo-Provera®150mg ', N'')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (6, N'DIU - Cobre', N'')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (7, N'DIU com progestativo - Mirena', N'')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (8, N'Espermicidas', N'')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (9, N'Preservativo', N'preservativo masculino ou feminino')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (10, N'Contracepção de Emergência', N'')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (11, N'Métodos de auto-observação', N'')
INSERT [dbo].[MetodoContracetivo] ([IdMetodoContracetivo], [nomeMetodoContracetivo], [observacoes]) VALUES (12, N'Laqueação tubária bilateral', N'')
SET IDENTITY_INSERT [dbo].[MetodoContracetivo] OFF
GO
INSERT [dbo].[MonitorizacaoECG] ([IdAtitude], [IdPaciente], [data], [monitorizacaoECG], [observacoes]) VALUES (27, 8013, CAST(N'2020-06-11' AS Date), N'dr', N'rtytr')
INSERT [dbo].[MonitorizacaoECG] ([IdAtitude], [IdPaciente], [data], [monitorizacaoECG], [observacoes]) VALUES (27, 8013, CAST(N'2020-06-13' AS Date), N'monitorizacao', N'obs')
GO
SET IDENTITY_INSERT [dbo].[Paciente] ON 

INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (1, N'paciente dfhg', CAST(N'2020-04-28' AS Date), N'paciente@mail.pt', 123456789, 123456789, N'paciente', 2, N'', N'leiria', NULL, N'2222', N'330', NULL, 3002, N'SNS', N'', NULL, N'', NULL, 125685425, N'Feminino', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4, N'Andreia', CAST(N'2020-10-03' AS Date), N'andreia@mail.pt', 111111111, 111222333, N'Rua de Cima', 12, NULL, N'leiria', NULL, N'2222', N'330', NULL, 3002, N'SNS', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (1002, N'David Simões', CAST(N'2020-10-03' AS Date), N'david@mail.pt', 123654899, 222111333, N'Rua de Cima', 20, NULL, N'Leiria', NULL, N'2222', N'330', NULL, 3002, N'SNS', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (1004, N'David Simões', CAST(N'2020-03-03' AS Date), N'sdfg@mail.pt', 111111111, 987654123, N'aqsedrty', 12, NULL, N'jkhgfd', NULL, N'2222', N'330', NULL, 3002, N'SNS', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (1005, N'Andreia', CAST(N'2020-04-03' AS Date), N'andreia26@mail.pt', 555555555, 111111111, N'sdfghjk', 1, NULL, N'kjhgf', NULL, N'2222', N'330', NULL, 3002, N'SNS', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (1006, N'Joana', CAST(N'1989-10-24' AS Date), N'joana@mail.pt', 123547896, 252525252, N'asdfgh', 1, N'RC 1º dir', N'rftg', NULL, N'2222', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 123654789, N'Feminino', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (2006, N'Ana Rodrigues', CAST(N'2020-10-03' AS Date), N'anaradrigues@mail.pt', 123568452, 125365452, N'sdfgh', 12, NULL, N'maceira', NULL, N'2222', N'330', NULL, 4003, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (2007, N'Joana Marques', CAST(N'2020-11-03' AS Date), N'joanaMarques@mail.pt', 123054632, 123520156, N'Rua Jenny', 5, NULL, N'maceira', NULL, N'2222', N'330', NULL, 4003, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (3006, N'Carlos Pedrosa', CAST(N'2000-12-07' AS Date), N'carlosPedrosa@mail.pt', 456203153, 125984563, N'Rua do Pêssego', 12, NULL, N'Localidade', NULL, N'2222', N'330', NULL, 4003, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (3008, N'Utente Um', CAST(N'2020-04-03' AS Date), N'utente@mail.pt', 123654852, 551203695, N'Morada Rua', 125, NULL, N'Localidade', NULL, N'2222', N'330', NULL, 4003, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4009, N'Ana Santos', CAST(N'2008-12-02' AS Date), N'anaS@mail.pt', 222555333, 555545555, N'Rua da Freguesia', 1, NULL, N'sdfg', NULL, N'2222', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 452154875, N'Feminino', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4010, N'Joaquim ', CAST(N'1979-10-07' AS Date), N'dsgr@mail.pt', 156845252, 121212121, N'kuui', 1, NULL, N'njhjkui', NULL, N'2222', N'330', NULL, 3003, N'Seguradora', N'dcfgh', 124520154, N'', NULL, NULL, N'Indefinido', N'Não Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4011, N'Bruna Carvalho', CAST(N'2020-12-03' AS Date), N'ola@mail.pt', 555444222, 222222222, N'Rua do X', 2, NULL, N'Localidade', NULL, N'2222', N'330', NULL, 3003, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4014, N'Manuel', CAST(N'2020-05-03' AS Date), N'emailManuel@ail.pt', 222111456, 222000444, N'dsfghj', 2, NULL, N'dfghj', NULL, N'2222', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 456456455, N'Masculino', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4016, N'Joana Santos', CAST(N'2020-03-03' AS Date), N'dsfghjkl@mail.pt', 252222222, 555555555, N'dfghjklç', 1, NULL, N'iyutgrfdsftyu', NULL, N'2222', N'330', NULL, 3003, N'Seguradora', N'rdfghjkl', 124544542, N'', NULL, NULL, N'Feminino', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4020, N'Maria', CAST(N'2020-10-06' AS Date), N'mariamaria@mail.pt', 555111111, 111333256, N'Maria', 1, NULL, N'maria', NULL, N'2222', N'330', NULL, 3003, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4021, N'Joel Simões', CAST(N'2020-04-03' AS Date), N'ydtre@ail.pt', 111111111, 444444444, N'Rua do X', 4, N'', N'fgytryt', NULL, N'2222', N'330', NULL, 3003, N'Seguradora', N'hyu', 467867638, N'', NULL, NULL, N'Masculino', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4023, N'Joao Mendes', CAST(N'2020-04-03' AS Date), N'joaoMendes@mail.pt', 125365423, 123321785, N'Rua do Andar', 456, NULL, N'Leiria', NULL, N'2222', N'330', NULL, 4003, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4029, N'Joana Santos', CAST(N'2020-05-04' AS Date), N'joanaNascimento@mail.pt', 123321156, 123321145, N'Rua Freguesia', 2, NULL, N'Maceira', NULL, N'2222', N'330', NULL, 5005, N'Seguradora', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (4030, N'Maria ', CAST(N'2020-05-04' AS Date), N'maria2@mail.pt', 159632452, 21456254, N'Rua do X', 5, NULL, N'Maceira', NULL, N'2222', N'330', NULL, 5005, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (5012, N'Andreia Fernandes', CAST(N'2020-08-04' AS Date), N'andreia2@mail.pt', 910848726, 235045262, N'Rua do Cafelado', 15, N'RC esq', N'Maceirinha', N'Maceirinha', N'2405', N'026', N'MACEIRA LRA', 4006, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (5016, N'sfdsdf', CAST(N'2020-03-03' AS Date), N'hjf@mail.pt', 111111111, 101010101, N'dfgdfg', 1, NULL, N'kjhkuy', NULL, N'2568', N'330', NULL, 4004, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (5019, N'jhhjh', CAST(N'2020-02-03' AS Date), N'dsret@mail.pt', 555555555, 999555123, N'erfer', 2, NULL, N'dfg', NULL, N'2568', N'330', NULL, 4006, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (6013, N'sdfghjk', CAST(N'2020-03-29' AS Date), N'sdfgh@mail.pt', 111111111, 525252525, N'dfghj', 1, NULL, N'sdfghjklç', NULL, N'2568', N'330', NULL, 4006, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (7013, N'ghj', CAST(N'2020-03-30' AS Date), N'asdfg@mail.pt', 678654234, 111222546, N'hjk', 2, NULL, N'gtrdytry', NULL, N'2568', N'330', NULL, 4003, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (7014, N'fghjhg', CAST(N'2020-04-09' AS Date), N'aaaa@mail.pt', 123654852, 563456415, N'yuyiuy', 2444, NULL, N'sfdghj', NULL, N'2568', N'330', NULL, 5005, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (7015, N'Joana Santos', CAST(N'2020-04-01' AS Date), N'ftguyt@mail.pt', 123543245, 456463546, N'dfghjkl', 5, NULL, N'yutyjugty', NULL, N'2568', N'330', NULL, 5005, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (7016, N'dfgfhgft', CAST(N'2020-04-08' AS Date), N'ftr@mail.pt', 75454645, 584653548, N'gftuyi', 24, NULL, N'fghytrygtry', NULL, N'2568', N'330', NULL, 5005, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (8013, N'Andreia Filipa Gomes Fernandes', CAST(N'2020-03-29' AS Date), N'dfgtrryrtu@mail.pt', 123654789, 666554286, N'dfgdfg', 2, NULL, N'fdgf', NULL, N'2568', N'330', NULL, 3003, N'Subsistema de Saúde', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (9014, N'Nome', CAST(N'2020-03-16' AS Date), N'sfgk@mail.pt', 123321225, 222554678, N'Rua do Utente', 2222, NULL, N'Loc', NULL, N'2568', N'330', NULL, 5005, N'SNS', NULL, NULL, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (10026, N'sdfghj', CAST(N'2019-12-30' AS Date), N'sdf@mail.pt', 125879461, 255421145, N'asdfgh', 202, NULL, N'fghjkl', NULL, N'2568', N'330', NULL, 3003, N'Seguradora', N'dxfdgfdg', 125468754, NULL, NULL, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (10027, N'Carlos da Silva Manuel', CAST(N'1944-06-20' AS Date), N'manuelSilva@mail.pt', 915452154, 123547843, N'Rua do Casal', 25, NULL, N'Marinha Grande', NULL, N'2568', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 123544855, N'Masculino', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (11027, N'Patricia Maria Marques', CAST(N'2004-06-15' AS Date), N'patriciaMarques@mail.pt', 458763546, 645645645, N'Rua do Carvalho', 2053, NULL, N'Carvalho', NULL, N'2568', N'330', NULL, 3003, N'Subsistema de Saúde', NULL, NULL, N'sadfrty', 245788965, NULL, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (12027, N'Ana Joaquina', CAST(N'1989-07-13' AS Date), N'anaJoaquina@mail.pt', 125888984, 564645687, N'Rua da rua', 125, NULL, N'Localidade', NULL, N'2568', N'330', NULL, 5005, N'SNS', NULL, NULL, NULL, NULL, 125796456, N'Feminino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (13027, N'sfsdffgdfgdfg', CAST(N'2020-04-28' AS Date), N'kajsdjsa@mail.pt', 456456456, 454564567, N'sfsdfg', 1452, NULL, N'hgfdsa', NULL, N'2568', N'330', NULL, 3002, N'SNS', NULL, NULL, NULL, NULL, 145854215, N'Masculino', N'Atualizado', 2)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (13028, N'eu', CAST(N'1993-05-10' AS Date), N'aSA@mail.pt', 456874562, 785462135, N'eu', 4125, N'', N'fcghjkl', NULL, N'2568', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 215482102, N'Indefinido', N'Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (14028, N'sdfghjkl', CAST(N'2020-05-06' AS Date), N'asdfghj@mail.pt', 452145634, 456456756, N'sdfghjmk', NULL, NULL, N'sdfghjk', NULL, N'2568', N'330', NULL, 3003, N'Subsistema de Saúde', N'', NULL, N'sdfg', 124578632, NULL, N'', N'', 1002)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (15028, N'fghjkl', CAST(N'2020-05-07' AS Date), N'tfhyrt@mail.pt', 464565465, 654645654, N'fgtytut', NULL, NULL, N'dgf', NULL, N'2568', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 245664564, N'Masculino', N'Não Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (15029, N'dsfdfdg', CAST(N'2020-05-06' AS Date), N'ghyutyu@mail.pt', 456464564, 546456856, N'fdgdfgfd', NULL, NULL, N'gfhgfhfghythg', NULL, N'2568', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 456456868, N'Feminino', N'Não Atualizado', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (16028, N'Fsdfdsfsdfsdfds', CAST(N'2020-04-29' AS Date), N'zfdf@mail.pt', 245567867, 876756546, N'dsfsdf', NULL, NULL, N'fgfghfg', NULL, N'2568', N'330', NULL, 3003, N'Subsistema de Saúde', N'', NULL, N'nome', 142456986, NULL, N'', N'', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (17028, N'Luís Pereira', CAST(N'2020-05-13' AS Date), NULL, 125465478, 655789879, N'Rua Principal', NULL, NULL, N'Localidade', NULL, N'2568', N'330', NULL, 3003, N'Seguradora', N'ftytugtuty', 458765431, N'kjhgfxdcfvgbhnj', 124865421, 254874521, N'', N'', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (18028, N'fdghjklçº', CAST(N'2020-04-27' AS Date), N'mariamria@mail.pt', 124578564, 685742311, N'kjhgfds', 4521, NULL, N'dfghjkl', NULL, N'2568', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 215487521, N'', N'', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (18034, N'huiui', CAST(N'2020-04-27' AS Date), N'sd4gh@mail.pt', 215875642, 225620444, N'opuii', NULL, NULL, N'cffty', NULL, N'2568', N'330', NULL, 3002, N'SNS', N'', NULL, N'', NULL, 123544845, N'', N'', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (19028, N'frtrfujytuiuyiku', CAST(N'2020-05-14' AS Date), N'tyrty@mail.pt', 487645785, 456789769, N'dfghjk', NULL, NULL, N'dfhghjuyi', NULL, N'2568', N'330', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 742587535, N'', N'', NULL)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (19032, N'dgtfty', CAST(N'2020-04-29' AS Date), N'dsff@mail.pt', 145753213, 655656556, N'fhgfhgh', 45, N'vbghnj', N'jhgfd', N'ghjk', N'2145', N'235', N'FDGHJ', 3003, N'SNS', N'', NULL, N'', NULL, 546786546, N'Feminino', N'Não Atualizado', 1)
INSERT [dbo].[Paciente] ([IdPaciente], [Nome], [DataNascimento], [Email], [Contacto], [Nif], [Rua], [NumeroCasa], [Andar], [localidade], [bairroLocal], [codPostalPrefixo], [codPostalSufixo], [designacao], [IdEnfermeiro], [Acordo], [NomeSeguradora], [NumeroApoliceSeguradora], [NomeSubsistema], [NumeroSubsistema], [NumeroSNS], [Sexo], [PlanoVacinacao], [IdProfissao]) VALUES (19034, N'sadsad', CAST(N'2020-04-30' AS Date), NULL, 785436879, 546879875, N'hjghj', NULL, NULL, N'hjgj', NULL, N'2544', N'454', NULL, 3003, N'SNS', N'', NULL, N'', NULL, 542457421, N'', N'', NULL)
SET IDENTITY_INSERT [dbo].[Paciente] OFF
GO
SET IDENTITY_INSERT [dbo].[Parto] ON 

INSERT [dbo].[Parto] ([IdParto], [tipoParto], [Observacoes]) VALUES (1, N'Eutócico', N'O parto eutócico é um parto normal, no qual não se verificam alterações e que se inicia e conclui de forma espontânea, sem necessidade de intervenção médica. Neste tipo de parto, o feto encontra-se em posição fetal cefálica e flexionada e a sua saída é vaginal.')
INSERT [dbo].[Parto] ([IdParto], [tipoParto], [Observacoes]) VALUES (2, N'Distócico', N'O parto distócico requer intervenção médica, normalmente procedimentos ou intervenções cirúrgicas, para a sua correta finalização. As causas que provocam um parto distócico podem ser variadas.')
INSERT [dbo].[Parto] ([IdParto], [tipoParto], [Observacoes]) VALUES (1002, N'Cesariana', N'A cesariana é uma intervenção cirúrgica para realizar o parto de um ou mais bebés. As cesarianas são muitas vezes necessárias nos casos em que um parto vaginal colocaria a mãe ou o bebé em risco')
INSERT [dbo].[Parto] ([IdParto], [tipoParto], [Observacoes]) VALUES (1003, N'fdgdfg', N'')
SET IDENTITY_INSERT [dbo].[Parto] OFF
GO
INSERT [dbo].[Pressoterapia] ([IdAtitude], [IdPaciente], [data], [membrosInferiores], [membrosSuperiores], [observacoes]) VALUES (28, 8013, CAST(N'2020-06-08' AS Date), NULL, N'po''0''', N'0''«0«0«')
INSERT [dbo].[Pressoterapia] ([IdAtitude], [IdPaciente], [data], [membrosInferiores], [membrosSuperiores], [observacoes]) VALUES (28, 8013, CAST(N'2020-06-09' AS Date), N'p0''', NULL, N'90''9')
INSERT [dbo].[Pressoterapia] ([IdAtitude], [IdPaciente], [data], [membrosInferiores], [membrosSuperiores], [observacoes]) VALUES (28, 8013, CAST(N'2020-06-10' AS Date), N'jio', N'ouo', NULL)
INSERT [dbo].[Pressoterapia] ([IdAtitude], [IdPaciente], [data], [membrosInferiores], [membrosSuperiores], [observacoes]) VALUES (28, 8013, CAST(N'2020-06-11' AS Date), NULL, NULL, N'iouio')
INSERT [dbo].[Pressoterapia] ([IdAtitude], [IdPaciente], [data], [membrosInferiores], [membrosSuperiores], [observacoes]) VALUES (28, 8013, CAST(N'2020-06-12' AS Date), NULL, N'opip', NULL)
INSERT [dbo].[Pressoterapia] ([IdAtitude], [IdPaciente], [data], [membrosInferiores], [membrosSuperiores], [observacoes]) VALUES (28, 8013, CAST(N'2020-06-13' AS Date), N'yuu', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[ProdutoStock] ON 

INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (1, N'nome', 0, 13, CAST(1.00 AS Numeric(5, 2)), N'yhui', 1)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (2, N'Compressas', 4, 6, CAST(4.00 AS Numeric(5, 2)), N'', 2)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (3, N'Compressas Feridas', 1, 6, CAST(2.00 AS Numeric(5, 2)), N'', 3)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (4, N'Desinfetante', -2, 6, CAST(2.50 AS Numeric(5, 2)), N'', 4)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (5, N'Pensos', 6, 6, CAST(2.53 AS Numeric(5, 2)), N'tamanho M', 5)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (1002, N'sdfghjk', 3, 6, CAST(3.00 AS Numeric(5, 2)), N'', 1)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (1003, N'Produto', -2, 6, CAST(2.00 AS Numeric(5, 2)), N'gbh', 2)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (1004, N'prod', -2, 6, CAST(3.53 AS Numeric(5, 2)), N'dsfghjkljuyj', 3)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (1008, N'Mascaras de Proteção Facial', 2, 6, CAST(6.00 AS Numeric(5, 2)), N'', 2)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (2005, N'fhgfhghg', 2, 6, CAST(7.00 AS Numeric(5, 2)), N'', 3)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (2006, N'Produto 23', 20, 13, CAST(3.89 AS Numeric(5, 2)), N'', 3)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (3005, N'mascaras', 10, 13, CAST(2.00 AS Numeric(5, 2)), N'', 4)
INSERT [dbo].[ProdutoStock] ([IdProdutoStock], [NomeProduto], [quantidadeArmazenada], [taxaIVA], [precoUnitario], [Observacoes], [IdFornecedor]) VALUES (3006, N'xdcfghj', 3, 23, CAST(5.00 AS Numeric(5, 2)), N'', 3)
SET IDENTITY_INSERT [dbo].[ProdutoStock] OFF
GO
SET IDENTITY_INSERT [dbo].[Profissao] ON 

INSERT [dbo].[Profissao] ([IdProfissao], [nomeProfissao]) VALUES (1, N'Estudante')
INSERT [dbo].[Profissao] ([IdProfissao], [nomeProfissao]) VALUES (2, N'Recessionista')
INSERT [dbo].[Profissao] ([IdProfissao], [nomeProfissao]) VALUES (1002, N'Contablista')
INSERT [dbo].[Profissao] ([IdProfissao], [nomeProfissao]) VALUES (2002, N'sadfgh')
INSERT [dbo].[Profissao] ([IdProfissao], [nomeProfissao]) VALUES (3002, N'Agricultor')
SET IDENTITY_INSERT [dbo].[Profissao] OFF
GO
INSERT [dbo].[Suturas] ([IdAtitude], [IdPaciente], [data], [id], [natural], [donatti], [observacoes]) VALUES (29, 8013, CAST(N'2020-06-08' AS Date), 45, NULL, NULL, N'lp+o')
INSERT [dbo].[Suturas] ([IdAtitude], [IdPaciente], [data], [id], [natural], [donatti], [observacoes]) VALUES (29, 8013, CAST(N'2020-06-09' AS Date), NULL, NULL, 45, N'poo+')
INSERT [dbo].[Suturas] ([IdAtitude], [IdPaciente], [data], [id], [natural], [donatti], [observacoes]) VALUES (29, 8013, CAST(N'2020-06-10' AS Date), NULL, 45, NULL, N'poo+')
INSERT [dbo].[Suturas] ([IdAtitude], [IdPaciente], [data], [id], [natural], [donatti], [observacoes]) VALUES (29, 8013, CAST(N'2020-06-11' AS Date), 45, 45, 45, N'tyyt')
INSERT [dbo].[Suturas] ([IdAtitude], [IdPaciente], [data], [id], [natural], [donatti], [observacoes]) VALUES (29, 8013, CAST(N'2020-06-12' AS Date), 45, NULL, NULL, N'poo+')
INSERT [dbo].[Suturas] ([IdAtitude], [IdPaciente], [data], [id], [natural], [donatti], [observacoes]) VALUES (29, 8013, CAST(N'2020-06-13' AS Date), 56, 56, 56, N'poo+')
GO
INSERT [dbo].[TesteAcuidadeVisual] ([IdAtitude], [IdPaciente], [data], [testeAcuidadeVisual], [observacoes]) VALUES (31, 8013, CAST(N'2020-06-10' AS Date), N'gjhgj', N'fghg')
INSERT [dbo].[TesteAcuidadeVisual] ([IdAtitude], [IdPaciente], [data], [testeAcuidadeVisual], [observacoes]) VALUES (31, 8013, CAST(N'2020-06-11' AS Date), N'fhf', N'fhggh')
INSERT [dbo].[TesteAcuidadeVisual] ([IdAtitude], [IdPaciente], [data], [testeAcuidadeVisual], [observacoes]) VALUES (31, 8013, CAST(N'2020-06-12' AS Date), N'ghgh', NULL)
INSERT [dbo].[TesteAcuidadeVisual] ([IdAtitude], [IdPaciente], [data], [testeAcuidadeVisual], [observacoes]) VALUES (31, 8013, CAST(N'2020-06-13' AS Date), NULL, N'ghhg')
GO
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 1006, CAST(N'2020-06-11' AS Date), NULL, NULL, NULL, NULL, 1020, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 1006, CAST(N'2020-06-12' AS Date), NULL, 1005, NULL, 1015, NULL, 1025, NULL, 8, NULL, NULL, N'3 +', NULL, NULL, NULL, NULL)
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 8013, CAST(N'2020-04-14' AS Date), NULL, 1005, NULL, NULL, NULL, NULL, NULL, 7, N'Neg', N'Pos', N'1 +', N'2 +', N'3 +', N'4 +', N'sdefgh')
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 8013, CAST(N'2020-04-27' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Neg', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 8013, CAST(N'2020-05-31' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Neg', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 8013, CAST(N'2020-06-01' AS Date), NULL, NULL, 1010, NULL, NULL, NULL, NULL, 7, N'Neg', NULL, N'1 +', N'2 +', N'3 +', N'4 +', NULL)
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 8013, CAST(N'2020-06-03' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'3 +', NULL, NULL, NULL, NULL)
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 8013, CAST(N'2020-06-09' AS Date), 1000, 1005, 1010, 1015, 1020, 1025, 1030, 8, N'Neg', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TesteCombur] ([IdAtitude], [IdPaciente], [data], [densidadeV1], [densidadeV2], [densidadeV3], [densidadeV4], [densidadeV5], [densidadeV6], [densidadeV7], [ph], [leucocitos ], [nitritos], [proteinas], [glucose], [cocetonicos], [sangeHemoglobina], [observacoes]) VALUES (30, 8013, CAST(N'2020-06-13' AS Date), 1000, 1005, 1010, 1015, 1020, 1025, 1030, 7, NULL, NULL, NULL, NULL, NULL, NULL, N'paciente estável')
GO
SET IDENTITY_INSERT [dbo].[tipoDespesa] ON 

INSERT [dbo].[tipoDespesa] ([IdTipoDespesa], [designacao], [observacoes]) VALUES (1002, N'Água', N'Despesa acontece uma vez por mês.')
INSERT [dbo].[tipoDespesa] ([IdTipoDespesa], [designacao], [observacoes]) VALUES (1003, N'Luz', N'Despesa acontece uma vez por mês.')
INSERT [dbo].[tipoDespesa] ([IdTipoDespesa], [designacao], [observacoes]) VALUES (1004, N'Encomendas', N'Despesa por ocorrer mais do que uma vez por mês.')
INSERT [dbo].[tipoDespesa] ([IdTipoDespesa], [designacao], [observacoes]) VALUES (1005, N'Outras', N'Despesa por ocorrer mais do que uma vez por mês.')
INSERT [dbo].[tipoDespesa] ([IdTipoDespesa], [designacao], [observacoes]) VALUES (1006, N'fgtyy', N'tyryr')
INSERT [dbo].[tipoDespesa] ([IdTipoDespesa], [designacao], [observacoes]) VALUES (2006, N'Portes de envio', N'Despesa pode ocorrer várias vezes ao mês')
SET IDENTITY_INSERT [dbo].[tipoDespesa] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoExame] ON 

INSERT [dbo].[tipoExame] ([IdTipoExame], [nome], [categoria], [designacao]) VALUES (1, N'Exame 1 ', N'categoria a ', N'designação')
INSERT [dbo].[tipoExame] ([IdTipoExame], [nome], [categoria], [designacao]) VALUES (2, N'Exame 2 ', N'Categoria ', N'Designação')
INSERT [dbo].[tipoExame] ([IdTipoExame], [nome], [categoria], [designacao]) VALUES (1002, N'Exame 3', N'categoria ', N'srftyuii')
INSERT [dbo].[tipoExame] ([IdTipoExame], [nome], [categoria], [designacao]) VALUES (2002, N'cbbv ', N'vbvb ', N'bvbvb')
INSERT [dbo].[tipoExame] ([IdTipoExame], [nome], [categoria], [designacao]) VALUES (3002, N'bnm', N'k,', N'..')
INSERT [dbo].[tipoExame] ([IdTipoExame], [nome], [categoria], [designacao]) VALUES (4002, N'Exame 4', N'kjhgfds', N'fghjkl')
SET IDENTITY_INSERT [dbo].[tipoExame] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoQueimadura] ON 

INSERT [dbo].[tipoQueimadura] ([IdTipoQueimadura], [tipoQueimadura]) VALUES (1, N'Térmica')
INSERT [dbo].[tipoQueimadura] ([IdTipoQueimadura], [tipoQueimadura]) VALUES (2, N'Química')
INSERT [dbo].[tipoQueimadura] ([IdTipoQueimadura], [tipoQueimadura]) VALUES (3, N'Iónica')
INSERT [dbo].[tipoQueimadura] ([IdTipoQueimadura], [tipoQueimadura]) VALUES (4, N'Solares')
INSERT [dbo].[tipoQueimadura] ([IdTipoQueimadura], [tipoQueimadura]) VALUES (2002, N'huiiy')
SET IDENTITY_INSERT [dbo].[tipoQueimadura] OFF
GO
SET IDENTITY_INSERT [dbo].[tipoUlcera] ON 

INSERT [dbo].[tipoUlcera] ([IdTipoUlcera], [tipoUlcera]) VALUES (1, N'Pressão')
INSERT [dbo].[tipoUlcera] ([IdTipoUlcera], [tipoUlcera]) VALUES (2, N'Arteriais')
INSERT [dbo].[tipoUlcera] ([IdTipoUlcera], [tipoUlcera]) VALUES (3, N'Venosas')
INSERT [dbo].[tipoUlcera] ([IdTipoUlcera], [tipoUlcera]) VALUES (4, N'Mistas')
INSERT [dbo].[tipoUlcera] ([IdTipoUlcera], [tipoUlcera]) VALUES (5, N'iopoipi')
INSERT [dbo].[tipoUlcera] ([IdTipoUlcera], [tipoUlcera]) VALUES (1005, N'ghf')
INSERT [dbo].[tipoUlcera] ([IdTipoUlcera], [tipoUlcera]) VALUES (1006, N'ulcera abc')
SET IDENTITY_INSERT [dbo].[tipoUlcera] OFF
GO
SET IDENTITY_INSERT [dbo].[Tratamento] ON 

INSERT [dbo].[Tratamento] ([IdTratamento], [nomeTratamento]) VALUES (1, N'Ferida Cirúrgica')
INSERT [dbo].[Tratamento] ([IdTratamento], [nomeTratamento]) VALUES (2, N'Ferida Traumática')
INSERT [dbo].[Tratamento] ([IdTratamento], [nomeTratamento]) VALUES (1002, N'Excisões')
INSERT [dbo].[Tratamento] ([IdTratamento], [nomeTratamento]) VALUES (1003, N'Queimaduras')
INSERT [dbo].[Tratamento] ([IdTratamento], [nomeTratamento]) VALUES (2002, N'Úlceras')
INSERT [dbo].[Tratamento] ([IdTratamento], [nomeTratamento]) VALUES (4002, N'dfdg')
SET IDENTITY_INSERT [dbo].[Tratamento] OFF
GO
INSERT [dbo].[TratamentoExcisoes] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [corpoEstranho], [dermica], [Observacoes], [dataProximoTratamento]) VALUES (1002, 1006, CAST(N'2020-06-03' AS Date), 1, N'fg', N'fg', NULL, NULL)
INSERT [dbo].[TratamentoExcisoes] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [corpoEstranho], [dermica], [Observacoes], [dataProximoTratamento]) VALUES (1002, 1006, CAST(N'2020-06-05' AS Date), 1, N'gh', N'fhgf', NULL, CAST(N'2020-07-02' AS Date))
INSERT [dbo].[TratamentoExcisoes] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [corpoEstranho], [dermica], [Observacoes], [dataProximoTratamento]) VALUES (1002, 1006, CAST(N'2020-06-08' AS Date), NULL, N'bvn', N'vbnvb', NULL, CAST(N'2020-06-09' AS Date))
INSERT [dbo].[TratamentoExcisoes] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [corpoEstranho], [dermica], [Observacoes], [dataProximoTratamento]) VALUES (1002, 8013, CAST(N'2020-06-03' AS Date), NULL, N'iuo', N'uoi', NULL, CAST(N'2020-07-10' AS Date))
INSERT [dbo].[TratamentoExcisoes] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [corpoEstranho], [dermica], [Observacoes], [dataProximoTratamento]) VALUES (1002, 8013, CAST(N'2020-06-26' AS Date), 2, N'u8', N'uy', N'yuiyi', CAST(N'2020-07-03' AS Date))
INSERT [dbo].[TratamentoExcisoes] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [corpoEstranho], [dermica], [Observacoes], [dataProximoTratamento]) VALUES (1002, 11027, CAST(N'2020-06-26' AS Date), 3, N'ftyry', N'rtyry', NULL, CAST(N'2020-07-03' AS Date))
GO
SET IDENTITY_INSERT [dbo].[TratamentoMaosPes] ON 

INSERT [dbo].[TratamentoMaosPes] ([IdTratamentoMaosPes], [tratamento], [observacoes]) VALUES (1, N'Onicocriptoses', NULL)
INSERT [dbo].[TratamentoMaosPes] ([IdTratamentoMaosPes], [tratamento], [observacoes]) VALUES (2, N'Onicomicoses', NULL)
INSERT [dbo].[TratamentoMaosPes] ([IdTratamentoMaosPes], [tratamento], [observacoes]) VALUES (3, N'Pé Diabético', NULL)
SET IDENTITY_INSERT [dbo].[TratamentoMaosPes] OFF
GO
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (1, 8013, CAST(N'2020-05-11' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (1, 8013, CAST(N'2020-06-26' AS Date), NULL, N'98080', NULL, NULL, NULL, N'i98', N'gh', N'gh', N'gh', N'gh', N'gh', N'gh', 0, N'ghjj', NULL, N'8908', N'Dor Muito Forte', NULL, NULL, NULL)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (2, 4011, CAST(N'2020-07-02' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, CAST(N'2020-07-16' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (1003, 1006, CAST(N'2020-06-08' AS Date), 1, N'1x5x4', N'2', N'uiu', 2, N'não', N'nada', N'nada', N'nada', N'nada', N'nada', N'nada', 2, N'2', CAST(N'2020-06-09' AS Date), N'nada', NULL, 3, N'hgjh', 1)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (2002, 1006, CAST(N'2020-06-08' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, N'hgjh', 1)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (2002, 8013, CAST(N'2020-05-31' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, N'546', 1)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (2002, 8013, CAST(N'2020-06-02' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (2002, 8013, CAST(N'2020-06-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, 1006)
INSERT [dbo].[TratamentoPaciente] ([IdTratamento], [IdPaciente], [data], [numeroTratamento], [dimensoes], [grauUlceraPressao], [exsudadoTipo], [exsudadoQuantidade], [exsudadoCheiro], [tecidoPredominante ], [areaCircundante], [agenteLimpeza], [aplicacaoFerida], [aplicacaoAreaCircundante], [aplicacaoPenso], [aplicacaoTamanho], [aplicacaoSuportePenso], [ProximoTratamento], [Observacoes], [EscalaDor], [tipoQueimadura], [IPTB], [tipoUlcera]) VALUES (4002, 8013, CAST(N'2020-06-26' AS Date), NULL, N'2x5x6', NULL, NULL, NULL, NULL, N'uyiyi', N'yiy', N'yuiy', N'uiyi', N'yuiy', N'huy', 1, N'yui', CAST(N'2020-07-03' AS Date), NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Tricotomia] ([IdAtitude], [IdPaciente], [data], [tricotomia], [observacoes]) VALUES (32, 8013, CAST(N'2020-06-12' AS Date), N'dfgf', N'fgfg')
INSERT [dbo].[Tricotomia] ([IdAtitude], [IdPaciente], [data], [tricotomia], [observacoes]) VALUES (32, 8013, CAST(N'2020-06-13' AS Date), N'ftyytu', NULL)
GO
SET IDENTITY_INSERT [dbo].[Vacinacao] ON 

INSERT [dbo].[Vacinacao] ([IdVacinacao], [IdPaciente], [data], [nomeVacina], [marcaComercial], [numeroInoculacao], [lote], [local], [escalaDor], [observacoes]) VALUES (1, 8013, CAST(N'2020-06-12' AS Date), N'ggh', N'ghg', N'ghg', N'hg', N'ghg', NULL, N'ghg')
INSERT [dbo].[Vacinacao] ([IdVacinacao], [IdPaciente], [data], [nomeVacina], [marcaComercial], [numeroInoculacao], [lote], [local], [escalaDor], [observacoes]) VALUES (2, 8013, CAST(N'2020-06-02' AS Date), N'fdrtt', N'ghjyu', N'456456', N'tyut', N'yutu', NULL, N'tyutu')
INSERT [dbo].[Vacinacao] ([IdVacinacao], [IdPaciente], [data], [nomeVacina], [marcaComercial], [numeroInoculacao], [lote], [local], [escalaDor], [observacoes]) VALUES (3, 8013, CAST(N'2020-06-09' AS Date), N'fhf', N'fghf', N'587', N'uoui', N'uiou', N'Dor Moderada', N'iouo')
INSERT [dbo].[Vacinacao] ([IdVacinacao], [IdPaciente], [data], [nomeVacina], [marcaComercial], [numeroInoculacao], [lote], [local], [escalaDor], [observacoes]) VALUES (1003, 8013, CAST(N'2020-06-12' AS Date), NULL, NULL, NULL, NULL, NULL, N'Dor Moderada', NULL)
SET IDENTITY_INSERT [dbo].[Vacinacao] OFF
GO
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (6, 1006, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (6, 8013, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (7, 1006, CAST(N'2020-06-12' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (7, 8013, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (7, 8013, CAST(N'2020-06-28' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (8, 1006, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (8, 4011, CAST(N'2020-07-02' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (8, 8013, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (9, 8013, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (10, 1006, CAST(N'2020-06-29' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (10, 8013, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (18, 4011, CAST(N'2020-07-02' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (18, 8013, CAST(N'2020-06-13' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (18, 8013, CAST(N'2020-06-28' AS Date))
INSERT [dbo].[VariasAtitudes] ([IdAtitude], [IdPaciente], [data]) VALUES (24, 8013, CAST(N'2020-06-13' AS Date))
GO
INSERT [dbo].[ZaragatoaOnofaringe] ([IdAtitude], [IdPaciente], [data], [zaragatoaOnofaringe], [observacoes]) VALUES (33, 8013, CAST(N'2020-06-11' AS Date), NULL, N'dfsfd')
INSERT [dbo].[ZaragatoaOnofaringe] ([IdAtitude], [IdPaciente], [data], [zaragatoaOnofaringe], [observacoes]) VALUES (33, 8013, CAST(N'2020-06-12' AS Date), N'frtytry', NULL)
INSERT [dbo].[ZaragatoaOnofaringe] ([IdAtitude], [IdPaciente], [data], [zaragatoaOnofaringe], [observacoes]) VALUES (33, 8013, CAST(N'2020-06-13' AS Date), N'rtet', N'rtrtyr')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Enfermei__AB6E6164129AC889]    Script Date: 02/07/2020 17:38:56 ******/
ALTER TABLE [dbo].[Enfermeiro] ADD UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Enfermei__F3DBC572B042EF0B]    Script Date: 02/07/2020 17:38:56 ******/
ALTER TABLE [dbo].[Enfermeiro] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__tmp_ms_x__C7D1D6C847A6B707]    Script Date: 02/07/2020 17:38:56 ******/
ALTER TABLE [dbo].[Paciente] ADD UNIQUE NONCLUSTERED 
(
	[Nif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
