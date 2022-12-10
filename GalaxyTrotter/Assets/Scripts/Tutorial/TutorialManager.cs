using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] textBoxes;
    [SerializeField] TextMeshProUGUI[] texts;
    [SerializeField] GameObject[] flechas;
    [SerializeField] GameObject clickScreen;
    [SerializeField] GameObject clickScreenSkipText;
    [SerializeField] Ingredient[] ingredients;
    [SerializeField] LiquidIngredient[] liquids;
    [SerializeField] GameObject tabletButton;
    [SerializeField] GameObject tablet;
    [SerializeField] PostitButton postit;

    [SerializeField] GameObject prepareButton;
    [SerializeField] GameObject resetButton;
    [SerializeField] GameObject rejectButton;

    [SerializeField] FoodPreparation foodPreparator;

    private bool skipText = false;
    [HideInInspector] public int numText = -1;
    private string textToPrint;
    private int textI = 0;
    private int condit = 0;
    private bool analizeLiquid = false;
    public bool soundPlaying;


    private void Start()
    {
        disableKitchen();
        nextText();
    }
    public void nextText()
    {
        numText++;
        textToPrint = "";
        switch (numText)
        {
            case 0:
                tabletButton.GetComponent<TabletButton>().inactive = true;
                textBoxes[0].SetActive(true);
                textToPrint = "Esta es la zona de preparaci�n de las bebidas, como puedes observar tienes varios ingredientes a tu alrededor.";
                textI = 0;
                condit = 0;
                break;
            case 1:
                textToPrint = "Bien, lo primero de todo que tienes que saber es la receta de la bebida que te pida el cliente.";
                break;
            case 2:
                textToPrint = "Toda la informaci�n que necesitas saber la tienes en esta tablet, c�gela.";
                flechas[0].SetActive(true);
                condit = 1;
                break;
            case 3:
                textBoxes[0].SetActive(false);
                flechas[0].SetActive(false);
                textI = 1;
                textBoxes[textI].SetActive(true);
                flechas[textI].SetActive(true);
                tablet.GetComponent<TabletManager>().tuto1 = true;
                condit = 1;
                textToPrint = "En este caso te he pedido un Tonight Please, as� que entra en el Recetario y busca la pesta�a del Tonight Please.";
                break;
            case 4:
                textBoxes[textI].SetActive(false);
                flechas[textI].SetActive(false);
                textI = 2;
                textBoxes[textI].SetActive(true);
                flechas[textI].SetActive(true);
                textToPrint = "Aqu� podr�s comprobar qu� ingredientes componen al Tonight Please. Te recomiendo ir aprendiendo las recetas disponibles, te ser� �til para ser m�s r�pido.";
                condit = -1;
                break;
            case 5:
                textBoxes[textI].SetActive(false);
                flechas[textI].SetActive(false);
                condit = -1;
                textI = 3;
                textBoxes[textI].SetActive(true);
                flechas[textI].SetActive(true);
                textToPrint = "Sal ahora del recetario para ver el resto de apartados que tiene la tablet.";
                condit = 0;
                break;
            case 6:
                textBoxes[textI].SetActive(false);
                flechas[textI].SetActive(false);
                condit = -1;

                break;
            case 7:
                textI = 1;
                textBoxes[textI].SetActive(true);
                textToPrint = "Como puedes ver aqu� tambi�n podr�s ver otras cosas como las reglas del bar, un mapa de la zona, informaci�n sobre los ingredientes, el historial de comandas donde podr�s comprobar en qu� has fallado y datos de las distintas especies que vienen al bar.";
                condit = 0;
                break;
            case 8:
                textToPrint = "Tambi�n tienes esta barra que marca tu reputaci�n profesional. La reputaci�n aumenta o disminuye seg�n tu rendimiento. Si fallas en la realizaci�n de las bebidas o incumples alguna regla se te penalizar�.";
                break;
            case 9:
                textToPrint = "Procura mantener la reputaci�n alta, si la barra se enrojece significa que est� demasiado baja, y por lo tanto, al final de la jornada me ver�a obligado a despedirte.";
                break;
            case 10:
                textToPrint = "En las reglas podr�s mirar las normas del local y las regulaciones del gobierno de Azius. Y en el bot�n de especies podr�s comprobar los ingredientes que no puede consumir cada especie.";
                break;
            case 11:
                textToPrint = "Recuerda revisarlo de vez en cuando, la tablet se actualiza cuando haya nuevas reglas o si se a�aden nuevas bebidas al bar.";
                break;
            case 12:
                textToPrint = "Bueno, eso es todo en cuanto a la tablet, pulsa el bot�n rojo para apagarla.";
                condit = 0;
                break;
            case 13:
                textBoxes[textI].SetActive(false);
                tablet.GetComponent<TabletManager>().tuto3 = true;
                condit = -1;
                break;
            case 14:
                tabletButton.GetComponent<TabletButton>().inactive = true;
                textI = 0;
                postit.inactive = true;
                textBoxes[textI].SetActive(true);
                textToPrint = "Pasemos ahora a preparar la bebida, antes de nada, observa que existen dos tipos de ingredientes, los que tienes aqu� en la balda central son l�quidos, mientras que el resto son s�lidos.";
                condit = 0;
                break;
            case 15:
                flechas[4].SetActive(true);
                textToPrint = "Por otro lado, ten en cuenta que el tiempo que tardes en realizar una bebida es muy importante. En este reloj podr�s mirar el tiempo con el que cuentas para terminar un pedido, si tard�s m�s de lo indicado seguramente el cliente se canse y esto perjudique en tu reputaci�n.";
                break;
            case 16:
                flechas[4].SetActive(false);
                textToPrint = "Tranquilo que como esto es una prueba no tendr� en cuenta el tiempo.";
                break;
            case 17:
                flechas[10].SetActive(true);
                textToPrint = "Por cierto, si en alg�n momento no recuerdas qu� bebida te ha pedido el cliente, puedes revisar la comanda aqu�. Por ahora no lo necesitas, yo te guiar�.";
                break;
            case 18:
                flechas[10].SetActive(false);
                flechas[5].SetActive(true);
                textToPrint = "Vale, una vez dicho esto, pasemos a lo importante. Como has visto, un Tonight Please lleva un 70% de sul, el sul es este ingrediente l�quido, c�gelo.";
                break;
            case 19:
                flechas[5].SetActive(false);
                flechas[6].SetActive(true);
                textBoxes[textI].SetActive(false);
                textBoxes[4].SetActive(true);
                textI = 4;
                textToPrint = "Para echarlo en la bebida tan solo tienes que arrastrarlo hasta el recipiente principal del medio.";
                break;
            case 20:
                textToPrint = "Al mantener el l�quido encima del recipiente este se ir� llenando. Puedes comprobar la cantidad que has echado en el nivel que aparece al lado, recuerda que en este caso debe tener un 70% de sul.";
                break;
            case 21:
                flechas[6].SetActive(false);
                textToPrint = "Tranquilo que si no eres exacto del todo no hay ning�n problema, apenas se nota cambio en el sabor. Pero siempre intenta acercarte a la cifra indicada todo lo que puedas";
                condit = 2;
                break;
            case 22:
                tabletButton.GetComponent<TabletButton>().inactive = true;
                flechas[7].SetActive(true);
                textToPrint = "Bien, ten en cuenta que si cometes alg�n error echando un ingrediente que no deb�as o te pasas en la cantidad de alg�n l�quido, puedes tirar esta bebida y empezar de nuevo pulsando el bot�n que tienes abajo a la derecha.";
                resetButton.SetActive(true);
                condit = 0; 
                break;
            case 23:
                textBoxes[textI].SetActive(false);
                textBoxes[0].SetActive(true);
                textI = 0;
                resetButton.SetActive(false);
                flechas[7].SetActive(false);
                textToPrint = "Pero ten en cuenta dos cosas, la primera que el tiempo corre, as� que trata de no equivocarte y as� no tendr�s que empezar otra vez.";
                break;
            case 24:
                textToPrint = "Y la segunda que al haber malgastado alg�n ingrediente no ganar�s reputaci�n en esa bebida, procura a�n as� hacerla bien para no perder.";
                break;
            case 25:
                flechas[8].SetActive(true);
                textToPrint = "El siguiente ingrediente del Tonight Please son 2 hongustars, para echarlos a la bebida c�gelos y arr�stralos hasta el recipiente.";
                condit = 3;
                break;
            case 26:
                tabletButton.GetComponent<TabletButton>().inactive = true;
                flechas[8].SetActive(false);
                textToPrint = "Uno m�s y ya habr�s terminado.";
                condit = 3;
                break;
            case 27:
                tabletButton.GetComponent<TabletButton>().inactive = true;
                flechas[9].SetActive(true);
                ingredients[0].disable();
                foodPreparator.tutorialIngredient = false;
                textToPrint = "Perfecto, ya has preparado un Tonight Please, ahora s�lo te queda entregarlo.";
                foodPreparator.tutorial = true;
                prepareButton.SetActive(true);
                condit = 4;
                break;
        }
        StartCoroutine(PrintCharacters(textToPrint,textI, condit));

    }
    IEnumerator PrintCharacters(string actualString, int i, int cond)
    {
        skipText = false;
        texts[i].text = "";
        clickScreenSkipText.SetActive(true);
        int index = 0;
        float t = 0;
        if (!soundPlaying)
        {
            FindObjectOfType<AudioManager>().Play("texto");
            soundPlaying = true;
        }
        while (index<actualString.Length)
        {
            t += Time.deltaTime / 0.02f;
            index = Mathf.FloorToInt(t);
            index = Mathf.Clamp(index, 0, actualString.Length);
            texts[i].text = actualString.Substring(0, index);
            if (skipText)
            {
                texts[i].text = actualString;
                index = actualString.Length;
            }
            yield return null;
        }
        soundPlaying = false;
        /*
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
                texts[i].text += character;
            }
            else
            {
                texts[i].text = actualString;
            }
        }
        if (skipText)
        {
            texts[i].text = actualString;
        }*/
        clickScreenSkipText.SetActive(false);
        switch (cond)
        {
            case 0:
                clickScreen.SetActive(true);
                break;
            case 1:
                tabletButton.GetComponentInChildren<TabletButton>().inactive = false;
                tabletButton.GetComponentInChildren<TabletButton>().tutorialActive = true;
                break;
            case 2:
                analizeLiquid = true;
                liquids[1].enable();
                break;
            case 3:
                foodPreparator.tutorialIngredient = true;
                ingredients[0].enable();
                break;
            case 4:
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
    private void goMain()
    {
        this.GetComponent<ChangeRoom>().goMain();
    }
    private void disableKitchen()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].disable();
        }
        for (int i = 0; i < liquids.Length; i++)
        {
            liquids[i].disable();
        }
        prepareButton.SetActive(false);
        resetButton.SetActive(false);
        rejectButton.SetActive(false);
        postit.inactive = true;
        //tabletButton.SetActive(false);
    }
    private void enableKitchen()
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].enable();
        }
        for (int i = 0; i < liquids.Length; i++)
        {
            liquids[i].enable();
        }
        prepareButton.SetActive(true);
        resetButton.SetActive(true);
        tabletButton.gameObject.SetActive(true);
        postit.inactive = false;
    }
    private void Update()
    {
        if (analizeLiquid)
        {
            if(foodPreparator.liquids[1] > 69.9)
            {
                analizeLiquid = false;
                liquids[1].disable();
                liquids[1].transform.position = liquids[1].initPos;
                liquids[1].transform.rotation = liquids[1].initRot;
                nextText();
            }
        }
    }
    public void endTutorial()
    {
        tablet.gameObject.GetComponent<TabletManager>().tuto4 = false;
        tabletButton.GetComponent<TabletButton>().inactive = false;
        flechas[9].SetActive(false);
        textBoxes[0].SetActive(false);
        enableKitchen();
        this.gameObject.SetActive(false);
    }
}
