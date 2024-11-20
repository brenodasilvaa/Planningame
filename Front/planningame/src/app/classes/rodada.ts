export class Rodada {
    numeroJogadores: number;
    todosVotaram: boolean;
    jogadores:Array<Jogadores> = new Array;
    brindou:boolean;
  }

  export class Jogadores{
    votou: boolean;
    nome: string;
  }