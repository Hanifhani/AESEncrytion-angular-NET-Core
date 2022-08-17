export class TransactionRequest{
    processingCode:string;
    systemTraceNr:string;
    functionCode:string;
    cardNo:string;
    cardHolder: string;
    amountTrxn:string;
    currencyCode:string;
    constructor() {
        this.processingCode = "";
        this.systemTraceNr= "";
        this.functionCode = "";
        this.cardNo = "";
        this.cardHolder = "";
        this.amountTrxn= "";
        this.currencyCode = "";
    }
    
}
export class TransactionResponse{
    ResponseCode!:string
    Message!: string 
    ApprovalCode!: string
    DateTime!: Date
    
}