class Trainer
{
    name: string;
    experience: number;
    constructor(name: string, experience: number){
        this.name=name;
        this.experience=experience;
    }
    introduce(): void{
        console.log(`Hi, I'm ${this.name} with ${this.experience} years of experience.`);
    }
    calculateSessions(): number {
        return this.experience * 75;
    }
}
const shiv=new Trainer("Siva",10);
shiv.introduce();
console.log(shiv.calculateSessions());