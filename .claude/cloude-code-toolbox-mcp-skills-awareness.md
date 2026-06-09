# Cloude Code ToolBox — MCP & Skills awareness

_Generated: 2026-06-01T13:23:46.777Z_

## How to use this report

- **Saved copy:** This file is **`.claude/cloude-code-toolbox-mcp-skills-awareness.md`** — refreshed whenever the toolbox runs an MCP & Skills scan (including on workspace open when auto-scan is enabled). It is meant for **Claude Code workspace context** together with `CLAUDE.md` (which gets a shorter replaceable summary when auto-merge is on).
- **MCP:** Lists **configured** servers from VS Code `mcp.json`. **Claude Code** uses `~/.claude/settings.json` and `/mcp` in the panel for its own MCP list — align or port configs as needed.
- **Skills:** **On-disk** folders with `SKILL.md`. Claude Code does not auto-load them; attach `SKILL.md` or paths in chat when useful.
- **Task routing:** When the user’s request matches a server’s purpose (e.g. Confluence → Confluence/Atlassian MCP), prefer that **server id** from the tables below.

---

## MCP — workspace

Workspace `mcp.json` _(folder: mini-station-goob)_

- **g:\SERVERS\mini-station-goob\.vscode\mcp.json** — _File missing_

_No active workspace servers in mcp.json._

## MCP — user profile

- **C:\Users\Mr. Samuel\AppData\Roaming\Code\User\mcp.json** — _File missing_

_No active user-scoped servers in mcp.json._

## Skills (local `SKILL.md` folders)

### Project-scoped

_None found (or no workspace open)._

### User-scoped

- **ss14-ecs-components** — `C:\Users\Mr. Samuel\.claude\skills\ss14-ecs-components`
  - This skill covers component architecture, attributes, and data patterns.

- **ss14-ecs-systems** — `C:\Users\Mr. Samuel\.claude\skills\ss14-ecs-systems`
  - This skill covers systems design, lifecycle, events, query and prediction.

- **ss14-graphics-generic-visualizer-appearance** — `C:\Users\Mr. Samuel\.claude\skills\ss14-graphics-generic-visualizer-appearance`
  - Практический и архитектурный гайд по связке AppearanceComponent, AppearanceSystem, VisualizerSystem и GenericVisualizer в SS14. Используй при проектировании сетевых визуальных состояний, YAML-визуализаций и клиентских vi

- **ss14-localization-code** — `C:\Users\Mr. Samuel\.claude\skills\ss14-localization-code`
  - This skill describes the rules for working with localization (`ILocalizationManager`) in the C# code of Space Station 14.

- **ss14-netcode-architecture** — `C:\Users\Mr. Samuel\.claude\skills\ss14-netcode-architecture`
  - The SS14 networking stack consists of several layers of abstraction, from low-level transport to game state synchronization logic:

- **ss14-potentially-visivble-set** — `C:\Users\Mr. Samuel\.claude\skills\ss14-potentially-visivble-set`
  - PVS (Potentially Visible Set) is a server system that determines **which entities each client sees**. Instead of sending the entire world to each player, the server filters the data by distance, visibility, and priority.

- **ss14-prediction** — `C:\Users\Mr. Samuel\.claude\skills\ss14-prediction`
  - In an online game, there is time (RTT) between pressing a button and the server responding. Without prediction, the player would press “move” and see the result 50–200 ms later. Prediction solves this: the client **immed

- **ss14-ecs-components** — `C:\Users\Mr. Samuel\.cursor\skills\ss14-ecs-components`
  - This skill covers component architecture, attributes, and data patterns.

- **ss14-ecs-systems** — `C:\Users\Mr. Samuel\.cursor\skills\ss14-ecs-systems`
  - This skill covers systems design, lifecycle, events, query and prediction.

- **ss14-event-subscription-safety** — `C:\Users\Mr. Samuel\.cursor\skills\ss14-event-subscription-safety`
  - Предотвращает дубли подписок SubscribeLocalEvent в SS14/Robust ECS и связанные падения Duplicate Subscriptions. Использовать при любых правках EntitySystem, Initialize(), event-хендлеров, контейнеров, рук и inventory.

- **ss14-localization-code** — `C:\Users\Mr. Samuel\.cursor\skills\ss14-localization-code`
  - This skill describes the rules for working with localization (`ILocalizationManager`) in the C# code of Space Station 14.

- **ss14-netcode-architecture** — `C:\Users\Mr. Samuel\.cursor\skills\ss14-netcode-architecture`
  - The SS14 networking stack consists of several layers of abstraction, from low-level transport to game state synchronization logic:

- **ss14-potentially-visivble-set** — `C:\Users\Mr. Samuel\.cursor\skills\ss14-potentially-visivble-set`
  - PVS (Potentially Visible Set) is a server system that determines **which entities each client sees**. Instead of sending the entire world to each player, the server filters the data by distance, visibility, and priority.

- **ss14-prediction** — `C:\Users\Mr. Samuel\.cursor\skills\ss14-prediction`
  - In an online game, there is time (RTT) between pressing a button and the server responding. Without prediction, the player would press “move” and see the result 50–200 ms later. Prediction solves this: the client **immed

---

## Suggested next steps

- **MCP:** Command Palette → `MCP: List Servers` (or this extension’s hub **MCP** tab). In Claude Code, use `/mcp` to connect servers for the Claude session.
- **Edit config:** `MCP: Open Workspace Folder MCP Configuration` / `MCP: Open User Configuration`.
- **Refresh this report:** run **Intelligence — scan MCP & Skills awareness** again after changing `mcp.json` or adding skills.

_Report from Cloude Code ToolBox extension._
