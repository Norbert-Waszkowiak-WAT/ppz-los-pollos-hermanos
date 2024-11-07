using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResponseHandler : MonoBehaviour
{
  [SerializeField] private RectTransform responseBox;
  [SerializeField] private RectTransform responseButtonTemplate;
  [SerializeField] private RectTransform responseCointainer;


  public void ShowResponses(Response[] responses)
  {
    float responseBoxHeight = 0;

    foreach(Response response in responses)
    {
        GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseCointainer);
        responseButton.gameObject.SetActive(true);
        responseButton.GetComponent<TMP_Text>().text=response.ResponseText;
        responseButton.GetComponent<Button>().onClick.AddListener(()=> OnPickedResponse(response));

        responseBoxHeight += responseButtonTemplate.sizeDelta.y;


    }

    responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, responseBoxHeight);
    responseBox.gameObject.SetActive(true);


  }

  private void OnPickedResponse(Response response)
  {






  }

  public void CloseResponse()
  {
     responseBox.gameObject.SetActive(false);
    
  }
 

}