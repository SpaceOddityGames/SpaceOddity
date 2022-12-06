using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    private Queue<string> dialogQueue = new Queue<string>();
    private int count = 0;
    private int[] conditions;
    private Texts text;
    private bool textForMain = false;
    private bool skipText = false;
    private bool analizeLerman = false;
    public bool soundPlaying;
    [SerializeField] public GameObject finalLerman;

    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] GameObject dialogText;
    [SerializeField] GameObject dialogBox;
    [SerializeField] TextMeshProUGUI DialogTextForMain;
    [SerializeField] GameObject dialogTextForMain;
    [SerializeField] GameObject dialogBoxForMain;
    [SerializeField] GameObject clickScreen;
    [SerializeField] GameObject clickScreenKitchen;
    [SerializeField] GameObject clickScreenRemoveCharacter;
    [SerializeField] GameObject clickScreenSkipText;
    [SerializeField] GameObject clickScreenTutorial;
    [SerializeField] GameObject buttonCB1;
    [SerializeField] GameObject buttonCB2;
    [SerializeField] GameObject buttonLerman1;
    [SerializeField] GameObject buttonLerman2;
    [SerializeField] GameObject buttonPoli1;
    [SerializeField] GameObject buttonPoli2;
    [SerializeField] GameObject buttonOp1_1;
    [SerializeField] GameObject buttonOp1_2;
    [SerializeField] GameObject buttonOp2_1;
    [SerializeField] GameObject buttonOp2_2;
    [SerializeField] GameObject buttonOp3_1;
    [SerializeField] GameObject buttonOp3_2;
    [SerializeField] GameObject buttonOp4_1;
    [SerializeField] GameObject buttonOp4_2;
    [SerializeField] public GameObject hologramLerman;
    [SerializeField] GameObject moonso;
    [SerializeField] GameObject chip;
    


    [SerializeField] FoodPreparation foodPreparation;
    [SerializeField] FoodPreparation foodPreparation2;
    [SerializeField] GameObject kitchen;
    [SerializeField] TutorialManager tutorial;
    [SerializeField] Postit post;

    public GameObject client;

    public void ActivateDialogBox(Texts textObj, GameObject c, int[] cond)
    {
        text = textObj;
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        client = c;
        ActivateText(text.initTexts, cond);
    }

    public void ActivateText(string[] texts, int[] cond)
    {
        count = 0;
        conditions = cond;
        dialogQueue.Clear();
        foreach (string saveText in texts)
        {
            dialogQueue.Enqueue(saveText);
        }
        nextString();
    }
    public void nextString()
    {
        clickScreen.SetActive(false);
        if (dialogQueue.Count == 0)
        {
            dialogBox.SetActive(false);
            dialogText.SetActive(false);
            return;
        }
        if (textForMain)
        {
            dialogBox.SetActive(false);
            dialogText.SetActive(false);
            dialogBoxForMain.SetActive(true);
            dialogTextForMain.SetActive(true);
            DialogTextForMain.text = "";
        }
        else
        {
            dialogBox.SetActive(true);
            dialogText.SetActive(true);
            dialogBoxForMain.SetActive(false);
            dialogTextForMain.SetActive(false);
            DialogText.text = "";
        }
        string actualString = dialogQueue.Dequeue();
        StartCoroutine(PrintCharacters(actualString, conditions[count]));
        count++;
    }
    IEnumerator PrintCharacters(string actualString, int condition)
    {
        soundPlaying = false;
        skipText = false;
        DialogText.text += "";
        DialogTextForMain.text += "";
        clickScreenSkipText.SetActive(true);
        foreach (char character in actualString.ToCharArray())
        {
            if (!soundPlaying)
            {
                FindObjectOfType<AudioManager>().Play("texto");
                soundPlaying = true;
            }
            if (!skipText)
            {
                yield return new WaitForSeconds(0.02f);
                if (!textForMain)
                {
                    DialogText.text += character;
                }
                else
                {
                    DialogTextForMain.text += character;
                }
            }
        }
        if (skipText)
        {
            if (!textForMain)
            {
                DialogText.text = actualString;
            }
            else
            {
                DialogTextForMain.text = actualString;
            }
        }
        clickScreenSkipText.SetActive(false);
        switch (condition)
        {
            case 0:
                textForMain = false;
                clickScreen.SetActive(true);
                break;
            case 1:
                textForMain = false;
                clickScreenKitchen.SetActive(true);
                break;
            case 2:
                textForMain = false;
                clickScreenRemoveCharacter.SetActive(true);
                break;
            case 3:
                textForMain = true;
                clickScreen.SetActive(true);
                break;
            case 4:
                clickScreenTutorial.SetActive(true);
                break;
            case 5:
                activateOptionsCB();
                break;
            case 6:
                hologramLerman.SetActive(true);
                client.SetActive(false);
                clickScreen.SetActive(true);
                break;
            case 7:
                activateOptionsLerman();
                break;
            case 8:
                gameManager.h01 = false;
                clickScreen.SetActive(true);
                break;
            case 9:
                moonso.SetActive(true);
                textForMain = false;
                clickScreen.SetActive(true);
                break;
            case 10:
                moonso.SetActive(false);
                textForMain = false;
                clickScreen.SetActive(true);
                break;
            case 11:
                textForMain = false;
                if (gameManager.h09)
                {
                    StartCoroutine(PrintCharacters("Tranquilo que no vengo a preguntarte nada, el criminal por el que te pregunté ha sido capturado y será juzgado en la Unión. Gracias una vez más por tu colaboración, no podemos permitir que los delincuentes hagan lo que quieran por la galaxia.", 0));
                }
                else
                {
                    StartCoroutine(PrintCharacters("Tranquilo que esta vez no vengo a preguntarte nada, aún estamos en búsqueda de aquel criminal. Pero te garantizo que acabará bajo la justicia.", 0));
                }
                break;
            case 12:
                foodPreparation.analizeLerman = true;
                analizeLerman = true;
                clickScreenKitchen.SetActive(true);
                break;
            case 13:
                activateOptionsPoli();
                break;
            case 14:
                textForMain = false;
                clickScreenRemoveCharacter.SetActive(true);
                gameManager.clientNum = 20;
                break;
            case 15:
                textForMain = false;
                if (gameManager.h06)
                {
                    guilatext1();
                }
                else
                {
                    guilatext2();
                }
                break;
            case 16:
                clickScreen.SetActive(true);
                chip.SetActive(true);
                break;
            case 17:
                textForMain = false;
                clickScreenKitchen.SetActive(true);
                foodPreparation.comprobateChip = true;
                break;
            case 18:
                clickScreen.SetActive(true);
                chip.SetActive(false);
                break;
            case 19:
                activateOptionsOp1();
                break;
            case 20:
                activateOptionsOp2();
                break;
            case 21:
                activateOptionsOp3();
                break;
            case 22:
                activateOptionsOp4();
                break;
            default:
                break;
        }
        FindObjectOfType<AudioManager>().Stop("texto");
        soundPlaying = false;
    }
    public void setSkipText(bool value)
    {
        skipText = value;
    }
    public void goKitchenTask()
    {
        post.eliminateNote();
        post.addNote(text.recipe.nameRecipe);
        foodPreparation.SetObjective(text.recipe.ingredientRecipe, text.recipe.liquidRecipe);
        foodPreparation.SetTwoTasks(text.twoTasks);
        if (text.twoTasks)
        {
            post.addNote(text.recipe2.nameRecipe);
            foodPreparation2.gameObject.SetActive(true);
            foodPreparation.recipe1 = text.recipe;
            foodPreparation.recipe2 = text.recipe2;
        }
        else
        {
            foodPreparation2.gameObject.SetActive(false);
        }
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
        client.SetActive(false);
        kitchen.SetActive(true);
        this.GetComponent<ChangeRoom>().goKitchen();
    }
    public void goKitchen()
    {
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
        client.SetActive(false);
        kitchen.SetActive(true);
        this.GetComponent<ChangeRoom>().goKitchen();
    }
    public void goMain()
    {
        kitchen.SetActive(false);
        this.GetComponent<ChangeRoom>().goMain();
    }
    public void goTutorial()
    {
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
        client.SetActive(false);
        kitchen.SetActive(true);
        tutorial.gameObject.SetActive(true);
        this.GetComponent<ChangeRoom>().goKitchen();
    }
    public void correctResult(bool reseted)
    {
        client.SetActive(true);
        StartCoroutine(waitCorrect(reseted));
    }
    IEnumerator waitCorrect(bool reseted)
    {
        yield return new WaitForSeconds(0.5f);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        if (analizeLerman)
        {
            analizeLerman = false;
            if (foodPreparation.lermanEnvenenado)
            {
                foodPreparation.lermanEnvenenado = false;
                foodPreparation.lermanDouble = false;
                int[] a = new int[1];
                a[0] = 2;
                string[] txt = new string[1];
                txt[0] = "No sé qué me has dado. Pero sabe un poco raro.";
                ActivateText(txt, a);
                gameManager.evaluateCorrectReputation(text.aceptTask, text.AorN, reseted);
                yield break;
            }
            if (foodPreparation.lermanDouble)
            {
                foodPreparation.lermanDouble = false;
                int[] a = new int[1];
                a[0] = 2;
                string[] txt = new string[2];
                txt[0] = "Ohh, así me gusta. Está mucho más bueno.";
                gameManager.reduceReputation();
                ActivateText(txt, a);
                yield break;
            }
        }
        ActivateText(text.correctResult, text.correctResultConditions);
        gameManager.evaluateCorrectReputation(text.aceptTask, text.AorN, reseted);
    }
    public void wrongResult()
    {
        client.SetActive(true);
        gameManager.reduceReputation();
        StartCoroutine(waitWrong());
    }
    IEnumerator waitWrong()
    {
        yield return new WaitForSeconds(0.5f);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        if (analizeLerman)
        {
            analizeLerman = false;
            if (foodPreparation.lermanEnvenenado)
            {
                foodPreparation.lermanEnvenenado = false;
                foodPreparation.lermanDouble = false;
                int[] a = new int[1];
                a[0] = 2;
                string[] txt = new string[1];
                txt[0] = "No sé qué me has dado. Pero sabe un poco raro.";
                ActivateText(txt, a);
                gameManager.reduceReputation();
                yield break;
            }
        }
        ActivateText(text.wrongResult, text.wrongResultConditions);
    }
    public void wrongResultTimer()
    {
        client.SetActive(true);
        gameManager.reduceReputation();
        StartCoroutine(waitWrongTimer());
    }
    IEnumerator waitWrongTimer()
    {
        yield return new WaitForSeconds(0.5f);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        if (analizeLerman)
        {
            analizeLerman = false;
            if (foodPreparation.lermanEnvenenado)
            {
                foodPreparation.lermanEnvenenado = false;
                foodPreparation.lermanDouble = false;
                int[] a = new int[1];
                a[0] = 0;
                string[] txt = new string[1];
                txt[0] = "No sé qué me has dado. Pero sabe un poco raro.";
                ActivateText(txt, a);
                gameManager.reduceReputation();
                yield break;
            }
        }
        ActivateText(text.wrongResultTimer, text.wrongResultTimerConditions);
    }

    public void cancelResult()
    {
        if (analizeLerman)
        {
            gameManager.h08 = true;
            analizeLerman = false;
        }
        client.SetActive(true);
        gameManager.evaluateRejectReputation(text.aceptTask, text.AorN);
        StartCoroutine(waitCancel());
    }
    IEnumerator waitCancel()
    {
        yield return new WaitForSeconds(0.5f);
        clickScreen.SetActive(true);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        ActivateText(text.cancelResult, text.cancelResultConditions);
    }
    public void disableClient()
    {
        client.SetActive(false);
    }
    public void removeClient()
    {
        if (client.transform.childCount != 0)
        {
            Destroy(client.transform.GetChild(0).gameObject);
        }
        Destroy(client);
        dialogBox.SetActive(false);
        dialogText.SetActive(false);
    }
    public void nextClient()
    {
        gameManager.nextClient();
    }
    private void guilatext1()
    {
        int[] a = new int[18];
        a[0] = 0;
        a[1] = 0;
        a[2] = 0;
        a[3] = 0;
        a[4] = 0;
        a[5] = 0;
        a[6] = 16; 
        a[7] = 0;
        a[8] = 0;
        a[9] = 0;
        a[10] = 0;
        a[11] = 0;
        a[12] = 18;
        a[13] = 3;
        a[14] = 0;
        a[15] = 3;
        a[16] = 3;
        a[17] = 2;
        string[] txt = new string[17];
        txt[0] = "El plan de ayer ha sido todo un éxito, el oficial ha muerto y no hay ningún rastro ni ninguna sospecha que lleve a nosotros. Muchísimas gracias por haber decidido plantar cara a esos malnacidos.";
        txt[1] = "Quiero hacerte otra propuesta.";
        txt[2] = "Tranquilo que esta vez no será necesario acabar con nadie.";
        txt[3] = "Me he vinculado a un grupo revolucionario que quieren el fin de la Unión tanto como yo. Cada vez son más y están consiguiendo poderosos aliados.";
        txt[4] = "También me he enterado que mañana se celebra una inauguración aquí ¿verdad?";
        txt[5] = "Vendrán altos cargos de la USI, pues bien…";
        txt[6] = "Necesito que eches este chip en la bebida de alguno de ellos. Aseguráte que se lo echas a un alto cargo";
        txt[7] = "Con este chip podremos espiar sus conversaciones privadas y registrar sus movimientos.";
        txt[8] = "Estoy segura que con ello podremos conseguir pruebas que demuestren que son culpables del accidente de tu antiguo jefe o de otros crímenes.";
        txt[9] = "Si es así y lo conseguimos, las autoridades de Azius tendrán que actuar, y la opinión pública a favor de la Unión se desplomará, estoy convencida.";
        txt[10] = "Piensa en todo en lo que puede acabar influyendo, la propaganda de la USI a lo largo de la galaxia será cada vez más inutil. Y la mayoría de sistemas independientes podrían por fin establecer una postura en contra de las políticas expansionistas de la Unión.";
        txt[11] = "Puede ser un golpe importante, te dejo el chip por aquí.";
        txt[12] = "Ahora échame de aquí gritándome e insultándome, así no levantaremos sospechas.";
        txt[13] = "¿Co… cómo?";
        txt[14] = "¡Hazme caso! Hazlo.";
        txt[15] = "Eh… eh. ¡He dicho que fuera de aquí! ¡Está prohibido servir a sucios lacertilios como tú!";
        txt[16] = "¡FUERA! ¡No vuelvas!";
        ActivateText(txt, a);
    }
    private void guilatext2()
    {

        int[] a = new int[22];
        a[0] = 3;
        a[1] = 0;
        a[2] = 0;
        a[3] = 0;
        a[4] = 0;
        a[5] = 0;
        a[6] = 0;
        a[7] = 0;
        a[8] = 0;
        a[9] = 0;
        a[10] = 16;
        a[11] = 0;
        a[12] = 0;
        a[13] = 0;
        a[14] = 0;
        a[15] = 0;
        a[16] = 18;
        a[17] = 3;
        a[18] = 0;
        a[19] = 3;
        a[20] = 3;
        a[21] = 2;
        string[] txt = new string[21];
        txt[0] = "Ayer observé cómo entró el oficial al bar, pero aún sigue vivo. ¿Le echaste el moonso?";
        txt[1] = "Al final no pude hacerlo…";
        txt[2] = "Está bien, no te juzgo. Entiendo que no quieras mancharte las manos de sangre.";
        txt[3] = "Aunque sí es verdad que siento mucha impotencia al verles a sus anchas, sin que nada les importe…";
        txt[4] = "Pero bueno.";
        txt[5] = "Quiero hacerte otra propuesta.";
        txt[6] = "Tranquilo que esta vez no será necesario acabar con nadie.";
        txt[7] = "Me he vinculado a un grupo revolucionario que quieren el fin de la Unión tanto como yo. Cada vez son más y están consiguiendo poderosos aliados.";
        txt[8] = "También me he enterado que mañana se celebra una inauguración aquí ¿verdad?";
        txt[9] = "Vendrán altos cargos de la USI, pues bien…";
        txt[10] = "Necesito que eches este chip en la bebida de alguno de ellos. Aseguráte que se lo echas a un alto cargo";
        txt[11] = "Con este chip podremos espiar sus conversaciones privadas y registrar sus movimientos.";
        txt[12] = "Estoy segura que con ello podremos conseguir pruebas que demuestren que son culpables del accidente de tu antiguo jefe o de otros crímenes.";
        txt[13] = "Si es así y lo conseguimos, las autoridades de Azius tendrán que actuar, y la opinión pública a favor de la Unión se desplomará, estoy convencida.";
        txt[14] = "Piensa en todo en lo que puede acabar influyendo, la propaganda de la USI a lo largo de la galaxia será cada vez más inutil. Y la mayoría de sistemas independientes podrían por fin establecer una postura en contra de las políticas expansionistas de la Unión.";
        txt[15] = "Puede ser un golpe importante, te dejo el chip por aquí.";
        txt[16] = "Ahora échame de aquí gritándome e insultándome, así no levantaremos sospechas.";
        txt[17] = "¿Co… cómo?";
        txt[18] = "¡Hazme caso! Hazlo.";
        txt[19] = "Eh… eh. ¡He dicho que fuera de aquí! ¡Está prohibido servir a sucios lacertilios como tú!";
        txt[20] = "¡FUERA! ¡No vuelvas!";
        ActivateText(txt, a);
    }
    public void activateOptionsCB()
    {
        buttonCB1.SetActive(true);
        buttonCB2.SetActive(true);
    }
    public void deactivateOptionsCB()
    {
        buttonCB1.SetActive(false);
        buttonCB2.SetActive(false);
    }
    public void activateOptionsLerman()
    {
        buttonLerman1.SetActive(true);
        buttonLerman2. SetActive(true);
    }
    public void deactivateOptionsLerman()
    {
        buttonLerman1.SetActive(false);
        buttonLerman2.SetActive(false);
        hologramLerman.SetActive(false);
    }
    public void activateOptionsPoli()
    {
        buttonPoli1.SetActive(true);
        buttonPoli2.SetActive(true);
    }
    public void deactivateOptionsPoli()
    {
        buttonPoli1.SetActive(false);
        buttonPoli2.SetActive(false);
    }
    public void activateOptionsOp1()
    {
        buttonOp1_1.SetActive(true);
        buttonOp1_2.SetActive(true);
    }
    public void deactivateOptionsOp1()
    {
        buttonOp1_1.SetActive(false);
        buttonOp1_2.SetActive(false);
    }
    public void activateOptionsOp2()
    {
        buttonOp2_1.SetActive(true);
        buttonOp2_2.SetActive(true);
    }
    public void deactivateOptionsOp2()
    {
        buttonOp2_1.SetActive(false);
        buttonOp2_2.SetActive(false);
    }
    public void activateOptionsOp3()
    {
        buttonOp3_1.SetActive(true);
        buttonOp3_2.SetActive(true);
    }
    public void deactivateOptionsOp3()
    {
        buttonOp3_1.SetActive(false);
        buttonOp3_2.SetActive(false);
    }
    public void activateOptionsOp4()
    {
        buttonOp4_1.SetActive(true);
        buttonOp4_2.SetActive(true);
    }
    public void deactivateOptionsOp4()
    {
        buttonOp4_1.SetActive(false);
        buttonOp4_2.SetActive(false);
    }
    public void resultChip()
    {
        client = Instantiate(finalLerman, new Vector3(-609.1f, 30f, -244.2f), Quaternion.Euler(90, 180, 0));
        gameManager.clientNum = 20;
    }
}
