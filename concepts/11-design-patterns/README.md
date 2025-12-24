# Design Patterns en .NET 🎨

## Introducción

Los Design Patterns (Patrones de Diseño) son soluciones reutilizables a problemas comunes en el diseño de software. Esta sección cubre patrones de diseño esenciales para aplicaciones .NET, especialmente útiles para arquitectura empresarial y aplicaciones escalables.

## 📚 Temas Disponibles

### 1. Unit of Work & Repository Pattern
**Ubicación:** `concepts/11-design-patterns/01-unit-of-work/`

Guía completa sobre los patrones Unit of Work y Repository en .NET Core trabajando juntos. Estos patrones proporcionan una abstracción sobre el acceso a datos y gestionan transacciones de manera eficiente.

**Conceptos Clave:**
- **Repository Pattern**: Actúa como puente entre la base de datos y la lógica de negocio
- **Unit of Work Pattern**: Asegura que múltiples operaciones se ejecuten como una sola transacción
- **Arquitectura en Capas**: Web Layer (Controllers), Core Layer (Business Logic & Repositories), Infra Layer (ORM & Database)
- **Trabajo Conjunto**: Los controladores interactúan con Unit of Work, que delega a repositorios, que usan ORM para acceder a la base de datos

**Beneficios:**
- ✅ Mejora la organización del código - Separación de responsabilidades
- ✅ Mejora la testabilidad - Facilita pruebas unitarias
- ✅ Simplifica interacciones con BD - Reduce código boilerplate
- ✅ Asegura consistencia de datos - Previene transacciones incompletas

---

## 🎯 Objetivo

Este apartado está diseñado para ayudarte a:
- Comprender patrones de diseño esenciales en .NET
- Implementar patrones de manera correcta y eficiente
- Integrar patrones con Entity Framework Core
- Mejorar la arquitectura y mantenibilidad de tus aplicaciones

## 📖 Principios de Design Patterns

- **Reusabilidad**: Soluciones probadas y reutilizables
- **Mantenibilidad**: Código más fácil de mantener y extender
- **Escalabilidad**: Arquitectura que crece con tu aplicación
- **Testabilidad**: Código más fácil de testear

