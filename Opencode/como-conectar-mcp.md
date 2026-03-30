opencode mcp add

Fazer a autenticação e pronto. 

Esse é o JSON do mcp local, caso queira fazer global só jogar no opencode.json

{
  "$schema": "https://opencode.ai/config.json",
  "mcp": {
    "notion": {
      "type": "remote",
      "url": "https://mcp.notion.com/mcp",
      "enabled": false
    }
  }
}