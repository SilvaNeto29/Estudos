A extensão deve ser instalada no wsl ou normal pra poder compartilhar código

Agent.md com /init guarda todas as instruções do projeto e pode e deve ser customizado.

O arquivo agends.md deve ser comitado para o github para todo o time e ter acesso às configurações do projeto e caso rodem opencode

Como usar:
How to use AGENTS.md?
1. Add AGENTS.md
Create an AGENTS.md file at the root of the repository. Most coding agents can even scaffold one for you if you ask nicely.
2. Cover what matters
Add sections that help an agent work effectively with your project. Popular choices:

Project overview
Build and test commands
Code style guidelines
Testing instructions
Security considerations
3. Add extra instructions
Commit messages or pull request guidelines, security gotchas, large datasets, deployment steps: anything you’d tell a new teammate belongs here too.
4. Large monorepo? Use nested AGENTS.md files for subprojects
Place another AGENTS.md inside each package. Agents automatically read the nearest file in the directory tree, so the closest one takes precedence and every subproject can ship tailored instructions. For example, at time of writing the main OpenAI repo has 88 AGENTS.md files.

Exemplo:
# Sample AGENTS.md file

## Dev environment tips
- Use `pnpm dlx turbo run where <project_name>` to jump to a package instead of scanning with `ls`.
- Run `pnpm install --filter <project_name>` to add the package to your workspace so Vite, ESLint, and TypeScript can see it.
- Use `pnpm create vite@latest <project_name> -- --template react-ts` to spin up a new React + Vite package with TypeScript checks ready.
- Check the name field inside each package's package.json to confirm the right name—skip the top-level one.

## Testing instructions
- Find the CI plan in the .github/workflows folder.
- Run `pnpm turbo run test --filter <project_name>` to run every check defined for that package.
- From the package root you can just call `pnpm test`. The commit should pass all tests before you merge.
- To focus on one step, add the Vitest pattern: `pnpm vitest run -t "<test name>"`.
- Fix any test or type errors until the whole suite is green.
- After moving files or changing imports, run `pnpm lint --filter <project_name>` to be sure ESLint and TypeScript rules still pass.
- Add or update tests for the code you change, even if nobody asked.

## PR instructions
- Title format: [<project_name>] <Title>
- Always run `pnpm lint` and `pnpm test` before committing.

No github é possível ver exemplos também 
https://agents.md/
------------------------------------------------------------------------------

## LSP


## Skills
Basicamente um jeito de falar - como fazer tal coisa aqui. Como trabalhar com docker, como, criar PRs, como trabalhar com migrations aqui. Comandos são prompts repetidos. 

Se quiser criar uma skill local, no repositório vai criar .opencode/skills/<name>/SKILL.md
Se quiser criar uma skill global, vai em ~/.config/opencode/skills/<name>/SKILL.md

## Comandos
Comandos no opencode é parecido com pensar no artisan. O artisan tinha comandos que já criavam direto os arquivos formatados. No opencode é possível criar os comandos para ele já fazer as coisas assim. 

O comando pode ser local dentro de .opencode
.opencode 
    commands/
        teste.md
        review.md
    skills
        pr_review/
            SKILL.md

ou global dentro de .config/opencode/opencode.json

/component tem a isntrução que criar um componente, aí você passaria /component Button e ele cria um componente chamado Button.

/test
/review
/ship
...

