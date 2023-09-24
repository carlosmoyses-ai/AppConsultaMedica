# Plataforma de Agendamento de Consultas Médicas

## Estrutura do Projeto

O projeto é estruturado em três partes principais:

1. **Modelo de Negócio (Library)**: Esta camada contém as classes e lógicas de negócio.
2. **Front End (ASP.NET Razor Pages)**: Interface de usuário para interação e visualização de dados.
3. **Back End (REST API)**: Serviços RESTful para gerenciar e processar os dados.

## Classes Básicas

- **Médico**: Representa os profissionais de saúde disponíveis para consulta. Atributos: nome, especialidade, número de registro profissional e horários disponíveis.
- **Paciente**: Representa os usuários que buscam agendar consultas. Atributos: nome, sobrenome, número de identificação e histórico médico.
- **Consulta**: Representa os agendamentos feitos pelos pacientes. Atributos: médico, paciente, data e hora, tipo de consulta (presencial ou online) e observações.
- **Especialidade**: Representa as áreas de atuação dos médicos. Atributos: nome da especialidade e descrição.
- **Recepcionista**: Representa os funcionários responsáveis pelo gerenciamento dos agendamentos. Atributos: nome, sobrenome, número de identificação e número de telefone.

## Associações

- Um médico pode ter várias consultas agendadas.
- Um paciente pode agendar várias consultas com diferentes médicos.
- Uma especialidade pode ser associada a vários médicos.
- Um recepcionista pode gerenciar vários agendamentos.

## Requisitos

- Utilize o framework ASP.NET Web Razor Pages para criar a interface de usuário.
- Implemente um CRUD para as classes Médico, Paciente, Consulta, Especialidade e Recepcionista.
- Implemente funcionalidades de agendamento, permitindo escolher médico, data e hora.
- Implemente um dashboard com resumos de consultas, médicos mais procurados e horários mais solicitados.
- Garanta a integridade dos dados com validações.
- Desenvolva uma API RESTful no backend para gerenciar e processar os dados, garantindo a comunicação entre o front end e o banco de dados.

## Entrega

A entrega deve ser feita através de um repositório Git público, contendo todas as camadas do projeto e um arquivo README.md com instruções de execução. A avaliação considerará a qualidade do código, aderência aos requisitos e funcionalidade geral.

## Foco do Problema

Desenvolver uma plataforma integrada que facilite o agendamento de consultas médicas, proporcionando uma experiência otimizada para médicos, pacientes e recepcionistas, e garantindo a eficiência na gestão de horários e especialidades.